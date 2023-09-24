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
    public partial class EditObj : Form
    {
        Objednavka obje = new Objednavka();
        Uzivatel uzivatel1 = new Uzivatel();
        Adresa adresa1 = new Adresa();
        BindingList<PolozkaObjednavky> bindinglist = new BindingList<PolozkaObjednavky>();
        public EditObj(Objednavka obj)
        {
            obje = obj;

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


            foreach (var b in PolozkaObjednavkyTable.Select(obje.Id))
            {
                bindinglist.Add(b);
            }
            dataGridView1.DataSource = bindinglist;

            Uzivatel u = UzivatelTable.Select(obje.zId)[0];
            Adresa a = AdresaTable.Select(u.IdAdresa)[0];
            uzivatel1 = u;
            adresa1 = a;


            namebox.Text = u.Jmeno;
            lastnamebox.Text = u.Prijmeni;
            phonebox.Text = u.Telefon;
            mailbox.Text = u.Email;
            streetbox.Text = a.Ulice;
            citybox.Text = a.Mesto;
            pscbox.Text = a.Psc;
            countrybox.Text = a.Zeme;


        }

        private void paybtn_Click(object sender, EventArgs e)
        {
            Platba platba = new Platba()
            {
                Datum_platby = DateTime.Now,
                Datum_zmeny = DateTime.Now,
                Cena = 1,
                Nazev = "Kartou"
            };
            PlatbaTable.Insert(platba);
            obje.pId = platba.Id;
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
                foreach (var b in bindinglist)
                {
                    if (b.pId == pObjednavky.pId)
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

                adresa1.Mesto = citybox.Text;
                adresa1.Ulice = streetbox.Text;
                adresa1.Psc = pscbox.Text;
                adresa1.Zeme = countrybox.Text;
                adresa1.Datum_zmeny = DateTime.Now;
               
                AdresaTable.Update(adresa1);

                uzivatel1.Jmeno = namebox.Text;
                uzivatel1.Prijmeni = lastnamebox.Text;
                uzivatel1.Telefon = phonebox.Text;
                uzivatel1.Email = mailbox.Text; 
                uzivatel1.Datum_zmeny = DateTime.Now;

                UzivatelTable.Update(uzivatel1);

                int id;
                if (radioButton3.Checked)
                {
                    id = 1;
                }
                else
                {
                    id = 2;
                }


                obje.dId = id;
                obje.Celkova_cena = 100;
                obje.Datum_zmeny = DateTime.Now;

    
                PolozkaObjednavkyTable.Delete(obje.Id);

                List<PolozkaObjednavky> polozkaObjednavky = new List<PolozkaObjednavky>();
                foreach (var b in bindinglist)
                {
                    polozkaObjednavky.Add(b);
                }
                int result = ObjednavkaTable.Update(obje);

                    foreach (var b in bindinglist)
                    {
                        b.oId = obje.Id;
                        PolozkaObjednavkyTable.Insert(b);

                    }
                    this.Hide();
             
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
