
namespace WindowsFormsApp
{
    partial class CreateProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.namebox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.manubox = new System.Windows.Forms.TextBox();
            this.descbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.weightbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pricebox = new System.Windows.Forms.TextBox();
            this.quantitybox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.kategorie = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(92, 44);
            this.namebox.Name = "namebox";
            this.namebox.PlaceholderText = "Název produktu";
            this.namebox.Size = new System.Drawing.Size(170, 23);
            this.namebox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(356, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Přidat";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // manubox
            // 
            this.manubox.Location = new System.Drawing.Point(92, 82);
            this.manubox.Name = "manubox";
            this.manubox.PlaceholderText = "Výrobce";
            this.manubox.Size = new System.Drawing.Size(137, 23);
            this.manubox.TabIndex = 2;
            // 
            // descbox
            // 
            this.descbox.Location = new System.Drawing.Point(92, 121);
            this.descbox.Name = "descbox";
            this.descbox.PlaceholderText = "Krátký popis produktu";
            this.descbox.Size = new System.Drawing.Size(402, 23);
            this.descbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nazev:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vyrobce:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Popis:";
            // 
            // colorbox
            // 
            this.colorbox.Location = new System.Drawing.Point(92, 159);
            this.colorbox.Name = "colorbox";
            this.colorbox.PlaceholderText = "Barva";
            this.colorbox.Size = new System.Drawing.Size(170, 23);
            this.colorbox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Barva:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hmotnost:";
            // 
            // weightbox
            // 
            this.weightbox.Location = new System.Drawing.Point(92, 198);
            this.weightbox.Name = "weightbox";
            this.weightbox.PlaceholderText = "Hmotnost v gramech";
            this.weightbox.Size = new System.Drawing.Size(115, 23);
            this.weightbox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cena:";
            // 
            // pricebox
            // 
            this.pricebox.Location = new System.Drawing.Point(92, 237);
            this.pricebox.Name = "pricebox";
            this.pricebox.PlaceholderText = "Cena za kus";
            this.pricebox.Size = new System.Drawing.Size(115, 23);
            this.pricebox.TabIndex = 12;
            // 
            // quantitybox
            // 
            this.quantitybox.Location = new System.Drawing.Point(92, 272);
            this.quantitybox.Name = "quantitybox";
            this.quantitybox.PlaceholderText = "Počet kusů ";
            this.quantitybox.Size = new System.Drawing.Size(115, 23);
            this.quantitybox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Počet kusů:";
            // 
            // kategorie
            // 
            this.kategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kategorie.FormattingEnabled = true;
            this.kategorie.Location = new System.Drawing.Point(92, 314);
            this.kategorie.Name = "kategorie";
            this.kategorie.Size = new System.Drawing.Size(115, 23);
            this.kategorie.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Kategorie:";
            // 
            // CreateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 412);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.kategorie);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.quantitybox);
            this.Controls.Add(this.pricebox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.weightbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.colorbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descbox);
            this.Controls.Add(this.manubox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.namebox);
            this.Name = "CreateProduct";
            this.Text = "Přidání produktu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox manubox;
        private System.Windows.Forms.TextBox descbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox colorbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox weightbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pricebox;
        private System.Windows.Forms.TextBox quantitybox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox kategorie;
        private System.Windows.Forms.Label label8;
    }
}