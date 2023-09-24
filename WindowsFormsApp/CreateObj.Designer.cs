
namespace WindowsFormsApp
{
    partial class CreateObj
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.namebox = new System.Windows.Forms.TextBox();
            this.lastnamebox = new System.Windows.Forms.TextBox();
            this.phonebox = new System.Windows.Forms.TextBox();
            this.mailbox = new System.Windows.Forms.TextBox();
            this.streetbox = new System.Windows.Forms.TextBox();
            this.citybox = new System.Windows.Forms.TextBox();
            this.pscbox = new System.Windows.Forms.TextBox();
            this.countrybox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(485, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(40, 255);
            this.namebox.Name = "namebox";
            this.namebox.PlaceholderText = "Jméno";
            this.namebox.Size = new System.Drawing.Size(100, 23);
            this.namebox.TabIndex = 1;
            // 
            // lastnamebox
            // 
            this.lastnamebox.Location = new System.Drawing.Point(155, 255);
            this.lastnamebox.Name = "lastnamebox";
            this.lastnamebox.PlaceholderText = "Příjmení";
            this.lastnamebox.Size = new System.Drawing.Size(118, 23);
            this.lastnamebox.TabIndex = 2;
            // 
            // phonebox
            // 
            this.phonebox.Location = new System.Drawing.Point(40, 284);
            this.phonebox.Name = "phonebox";
            this.phonebox.PlaceholderText = "Telefonní číslo";
            this.phonebox.Size = new System.Drawing.Size(142, 23);
            this.phonebox.TabIndex = 3;
            // 
            // mailbox
            // 
            this.mailbox.Location = new System.Drawing.Point(40, 313);
            this.mailbox.Name = "mailbox";
            this.mailbox.PlaceholderText = "Emailová adresa";
            this.mailbox.Size = new System.Drawing.Size(201, 23);
            this.mailbox.TabIndex = 4;
            // 
            // streetbox
            // 
            this.streetbox.Location = new System.Drawing.Point(40, 342);
            this.streetbox.Name = "streetbox";
            this.streetbox.PlaceholderText = "Ulice";
            this.streetbox.Size = new System.Drawing.Size(272, 23);
            this.streetbox.TabIndex = 5;
            // 
            // citybox
            // 
            this.citybox.Location = new System.Drawing.Point(40, 371);
            this.citybox.Name = "citybox";
            this.citybox.PlaceholderText = "Město";
            this.citybox.Size = new System.Drawing.Size(142, 23);
            this.citybox.TabIndex = 6;
            // 
            // pscbox
            // 
            this.pscbox.Location = new System.Drawing.Point(40, 400);
            this.pscbox.Name = "pscbox";
            this.pscbox.PlaceholderText = "PSČ";
            this.pscbox.Size = new System.Drawing.Size(100, 23);
            this.pscbox.TabIndex = 7;
            // 
            // countrybox
            // 
            this.countrybox.Location = new System.Drawing.Point(173, 400);
            this.countrybox.Name = "countrybox";
            this.countrybox.PlaceholderText = "Země";
            this.countrybox.Size = new System.Drawing.Size(139, 23);
            this.countrybox.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Location = new System.Drawing.Point(342, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 46);
            this.button1.TabIndex = 11;
            this.button1.Text = "Vytvořit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Přidat produkt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(269, 197);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton3.Location = new System.Drawing.Point(25, 24);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(75, 23);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Osobně";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton4.Location = new System.Drawing.Point(159, 24);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(69, 23);
            this.radioButton4.TabIndex = 16;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Poštou";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(40, 442);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 55);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Druh dopravy:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Osobní údaje:";
            // 
            // CreateObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 572);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.countrybox);
            this.Controls.Add(this.pscbox);
            this.Controls.Add(this.citybox);
            this.Controls.Add(this.streetbox);
            this.Controls.Add(this.mailbox);
            this.Controls.Add(this.phonebox);
            this.Controls.Add(this.lastnamebox);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CreateObj";
            this.Text = "Vytvoření objednávky";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.TextBox lastnamebox;
        private System.Windows.Forms.TextBox phonebox;
        private System.Windows.Forms.TextBox mailbox;
        private System.Windows.Forms.TextBox streetbox;
        private System.Windows.Forms.TextBox citybox;
        private System.Windows.Forms.TextBox pscbox;
        private System.Windows.Forms.TextBox countrybox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}