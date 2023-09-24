using MobilObchod.ORM;
using MobilObchod.ORM.dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        BindingList<Objednavka> bindingList = new BindingList<Objednavka>();
        public  List<Uzivatel> Users { get; set; }
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "číslo objednávky",
                DataPropertyName = nameof(Objednavka.Id)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "datum vytvoření",
                DataPropertyName = nameof(Objednavka.Datum_vytvoreni)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "stav",
                DataPropertyName = nameof(Objednavka.Stav)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "celkova cena",
                DataPropertyName = nameof(Objednavka.Celkova_cena)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "druh platby",
                DataPropertyName = nameof(Objednavka.druh_platby)
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "druh dopravy",
                DataPropertyName = nameof(Objednavka.druh_dopravy)
            });
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Smazání",
                Name = "Delete"
            }) ;
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Upravit",
                Name = "Edit"
            });
            Refresh();
        }
        private void Refresh(int? keyword=null)
        {
            Collection<Objednavka> orders = ObjednavkaTable.Select(keyword:keyword);
            bindingList.Clear();
            bindingList = new BindingList<Objednavka>(orders);
            dataGridView1.DataSource = bindingList;
        }
           
        private void Form1_Load(object sender, EventArgs e)
        {
            Collection<Objednavka> orders = ObjednavkaTable.Select();
            BindingList<Objednavka> bindingList = new BindingList<Objednavka>(orders);
            dataGridView1.DataSource = bindingList;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < bindingList.Count; i++)
            {
                if (bindingList[i].Stav == "Storno")
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

            Objednavka obj = bindingList[e.RowIndex];
            if (datagrid.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (datagrid.Rows[e.RowIndex].Cells["Delete"] is DataGridViewButtonCell)
                {
                    ObjednavkaTable.Delete(obj);
                    Refresh();

                }
            }
            else if (datagrid.Columns[e.ColumnIndex].Name == "Edit")
            {
                EditObj editObjForm = new EditObj(obj);
                editObjForm.ShowDialog();
                Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                bool success = false;
                int id;
                success = Int32.TryParse(textBox1.Text, out id);
                if (success == true)
                {
                    Refresh(id);
                    return;
                }
            }
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateObj createObjForm = new CreateObj();
            createObjForm.Show();
            Refresh();
        }

        private void checkState_Click(object sender, EventArgs e)
        {
            ObjednavkaTable.State();
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
