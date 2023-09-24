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
    public partial class CreateProduct : Form
    {
        public CreateProduct()
        {
            InitializeComponent();
            Collection<Kategorie> kat = KategorieTable.Select();
            foreach (var k in kat)
            {
                kategorie.Items.Add(k);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (namebox.Text != "" && manubox.Text != "" && descbox.Text != "" && colorbox.Text != "" && weightbox.Text != "" && pricebox.Text != "" && quantitybox.Text != "")
            {
                Produkt produkt = new Produkt();

                produkt.Nazev = namebox.Text;
                produkt.Vyrobce = manubox.Text;
                produkt.Popis = descbox.Text;
                produkt.Barva = colorbox.Text;
                produkt.Datum_pridani = DateTime.Now;
                produkt.Datum_zmeny = DateTime.Now;

                if(kategorie.SelectedIndex < 0)
                {
                    MessageBox.Show("Nevybrana kategorie.", "Přidání produktu", MessageBoxButtons.OK);
                    return;
                }

                Kategorie k = kategorie.SelectedItem as Kategorie;


                int weight;
                if(!Int32.TryParse(weightbox.Text, out weight))
                {
                    MessageBox.Show("musis zadat cislo", "input", MessageBoxButtons.OK);
                    return;
                }
                produkt.Hmotnost = weight;
                int price;
                if (!Int32.TryParse(pricebox.Text, out price))
                {
                    MessageBox.Show("musis zadat cislo", "input", MessageBoxButtons.OK);
                    return;
                }
                produkt.Cena = price;
                int quantity;
                if (!Int32.TryParse(pricebox.Text, out quantity))
                {
                    MessageBox.Show("musis zadat cislo", "input", MessageBoxButtons.OK);
                    return;
                }         
                produkt.Pocet_kusu = quantity;

                ProduktTable.Insert(produkt);

                ProduktKategorie pk = new ProduktKategorie();
                pk.Produkt = new Produkt();
                pk.Kategorie = new Kategorie();

                pk.Produkt.Id = produkt.Id;
                pk.Kategorie.Id = k.Id;

                ProduktKategorieTable.Insert(pk);
                MessageBox.Show("Produkt byl přidán.", "Přidání produktu", MessageBoxButtons.OK);

                Hide();
            }
        }
    }
}
