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
    public partial class OverviewProducts : Form
    {
        BindingList<ListProdukt> bindingList = new BindingList<ListProdukt>();
        string keyword="";
        string kategorie="Android";
        int orderAttr=1;
        char orderby='D';
        public OverviewProducts()
        {   
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Název",

            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Popis",

            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Výrobce",
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Počet prodaných kusů",
          
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Počet kusů skladem",
               
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Cena",
              
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Kategorie název",

            });
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Smazat",
                Name = "Delete"
            });
            Refresh();

        }
        private void Refresh(string keyword="",string kategorie="Android",int orderAttr=1, char orderby='D')
        {
            Collection<ListProdukt> products = ProduktTable.SelectAll(keyword: keyword, kategorie: kategorie, orderAttr:orderAttr, orderby:orderby);
              bindingList.Clear();
              bindingList = new BindingList<ListProdukt>(products);
            /*
              dataGridView1.DataSource = bindingList;
           */
            dataGridView1.Rows.Clear();
            foreach(var p in products)
            {
                dataGridView1.Rows.Add(p.Produkt.Nazev, p.Produkt.Popis, p.Produkt.Vyrobce, p.Sum, p.Produkt.Pocet_kusu, p.Produkt.Cena, p.KatNazev);
            }
        }

        private void OverviewProducts_Load(object sender, EventArgs e)
        {
            /*
            Collection<ListProdukt> products = ProduktTable.SelectAll(keyword: keyword , kategorie: kategorie, orderAttr: orderAttr, orderby: orderby);
            BindingList<ListProdukt> bindingList = new BindingList<ListProdukt>(products);
            dataGridView1.DataSource = bindingList;
            */
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < bindingList.Count; i++)
            {
                if (bindingList[i].Produkt.isActive == false)
                {
                    dataGridView1.Rows[i].Cells["Delete"] = new DataGridViewTextBoxCell()
                    {
                        Value = "Nelze smazat"
                    };
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView datagrid = sender as DataGridView;

            ListProdukt produkt = bindingList[e.RowIndex];
            if (datagrid.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (datagrid.Rows[e.RowIndex].Cells["Delete"] is DataGridViewButtonCell)
                {
                    ProduktTable.Delete(produkt.Produkt);
                    Refresh();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                keyword = null;
            }
            else
            {
                keyword = textBox1.Text;
            }

            if(radioButton4.Checked)
            {
                kategorie = "Android";
            }
            if(radioButton5.Checked)
            {
                kategorie = "iOS";
            }

            if (radioButton1.Checked)
            {
                orderAttr = 1;
            }
            else if (radioButton2.Checked)
            {
                orderAttr = 2;
            }
            else if (radioButton3.Checked)
            {
                orderAttr = 3;
            }

            if(comboBox1.SelectedIndex >= 0)
            {
                if(comboBox1.SelectedIndex == 0)
                {
                    orderby = 'D';
                }
                else if(comboBox1.SelectedIndex == 1)
                {
                    orderby = 'A';
                }
            }

            Refresh(keyword,kategorie,orderAttr,orderby);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.Show();
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
