using MobilObchod.ORM;
using MobilObchod.ORM.dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class CreateObj : Form
    {
        BindingList<PolozkaObjednavky> bindinglist = new BindingList<PolozkaObjednavky>();

        public CreateObj()
        {
            InitializeComponent();
            Collection<Produkt> products = ProduktTable.SelectProducts();
            foreach (var p in products)
            {
                comboBox1.Items.Add(p);
            }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Nazev produktu",
                DataPropertyName = nameof(PolozkaObjednavky.NazevProduktu)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mnozstvi",
                DataPropertyName = nameof(PolozkaObjednavky.Mnozstvi)
            });
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "-",
                Name = "decrement"
            });

            dataGridView1.DataSource = bindinglist;

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView datagrid = sender as DataGridView;

            PolozkaObjednavky obj = bindinglist[e.RowIndex];
            if (datagrid.Columns[e.ColumnIndex].Name == "decrement")
            {
                if (datagrid.Rows[e.RowIndex].Cells["decrement"] is DataGridViewButtonCell)
                {
                    bindinglist[e.RowIndex].Mnozstvi--;
                    if (bindinglist[e.RowIndex].Mnozstvi <= 0)
                    {
                        bindinglist.Remove(obj);
                    }
                    dataGridView1.Refresh();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (namebox.Text != "" && lastnamebox.Text != "" && phonebox.Text != "" && mailbox.Text != "" && streetbox.Text != "" && citybox.Text != "" && pscbox.Text != "" && countrybox.Text != "")
            {
                bool success = false;
                int psc;
                success = Int32.TryParse(pscbox.Text, out psc);
                if (success == false)
                {
                    // return;
                }
                Adresa adresa = new Adresa()
                {
                    Mesto = citybox.Text,
                    Ulice = streetbox.Text,
                    Psc = pscbox.Text,
                    Zeme = countrybox.Text,
                    Datum_zmeny = DateTime.Now
                };
                AdresaTable.Insert(adresa);
                Uzivatel uzivatel = new Uzivatel()
                {
                    Jmeno = namebox.Text,
                    Prijmeni = lastnamebox.Text,
                    Telefon = phonebox.Text,
                    Email = mailbox.Text,
                    IdAdresa = adresa.Id,
                    Is_active = true,
                    Typ_uzivatele = "neregistrovany zakaznik",
                    Adresa = adresa,
                    Datum_zmeny = DateTime.Now
                 
                };

                UzivatelTable.Insert(uzivatel);

                int id;
                if (radioButton3.Checked)
                {
                    id = 1;
                }
                else
                {
                    id = 2;
                }


                Objednavka objednavka = new Objednavka()
                {
                    zId = uzivatel.Id,
                    Stav = "Prijata",
                    dId = id,
                    Celkova_cena = 0,
                    Datum_vytvoreni = DateTime.Now,
                    Datum_zmeny = DateTime.Now
            };
                List<PolozkaObjednavky> polozkaObjednavky = new List<PolozkaObjednavky>();
                foreach(var b in bindinglist)
                {
                    polozkaObjednavky.Add(b);
                }
                int result = ObjednavkaTable.Insert(objednavka, polozkaObjednavky);

                if (result == 1)
                {
                    foreach (var b in bindinglist)
                    {
                        b.oId = objednavka.Id;
                        PolozkaObjednavkyTable.Insert(b);

                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Objednavku se nepodarilo vytvorit", "Vytvoreni objednavky", MessageBoxButtons.OK);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                Produkt p1 = comboBox1.SelectedItem as Produkt;
                PolozkaObjednavky pObjednavky = new PolozkaObjednavky();
                pObjednavky.Mnozstvi = 1;
                pObjednavky.pId = p1.Id;
                pObjednavky.NazevProduktu = p1.Nazev;

                bool exists = false;
                foreach(var b in bindinglist)
                {
                    if(b.pId == pObjednavky.pId)
                    {
                        exists = true;
                        b.Mnozstvi += 1;
                    }
                }
                if (exists == false)
                {
                    bindinglist.Add(pObjednavky);
                    
                }
                dataGridView1.Refresh();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < bindinglist.Count; i++)
            {
                if (bindinglist[i].Mnozstvi < 1)
                {
                    dataGridView1.Rows[i].Cells["decrement"] = new DataGridViewTextBoxCell()
                    {
                        Value = ""
                    };
                }
            }
        }
    }
}
