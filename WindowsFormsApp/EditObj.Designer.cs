
namespace WindowsFormsApp
{
    partial class EditObj
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.countrybox = new System.Windows.Forms.TextBox();
            this.pscbox = new System.Windows.Forms.TextBox();
            this.citybox = new System.Windows.Forms.TextBox();
            this.streetbox = new System.Windows.Forms.TextBox();
            this.mailbox = new System.Windows.Forms.TextBox();
            this.phonebox = new System.Windows.Forms.TextBox();
            this.lastnamebox = new System.Windows.Forms.TextBox();
            this.namebox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.paybtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(267, 226);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 30;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 225);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Přidat produkt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 590);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 44);
            this.button1.TabIndex = 28;
            this.button1.Text = "Uložit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // countrybox
            // 
            this.countrybox.Location = new System.Drawing.Point(179, 428);
            this.countrybox.Name = "countrybox";
            this.countrybox.PlaceholderText = "Země";
            this.countrybox.Size = new System.Drawing.Size(140, 23);
            this.countrybox.TabIndex = 27;
            // 
            // pscbox
            // 
            this.pscbox.Location = new System.Drawing.Point(51, 428);
            this.pscbox.Name = "pscbox";
            this.pscbox.PlaceholderText = "Psč";
            this.pscbox.Size = new System.Drawing.Size(86, 23);
            this.pscbox.TabIndex = 26;
            // 
            // citybox
            // 
            this.citybox.Location = new System.Drawing.Point(51, 399);
            this.citybox.Name = "citybox";
            this.citybox.PlaceholderText = "Město";
            this.citybox.Size = new System.Drawing.Size(145, 23);
            this.citybox.TabIndex = 25;
            // 
            // streetbox
            // 
            this.streetbox.Location = new System.Drawing.Point(51, 370);
            this.streetbox.Name = "streetbox";
            this.streetbox.PlaceholderText = "Ulice";
            this.streetbox.Size = new System.Drawing.Size(268, 23);
            this.streetbox.TabIndex = 24;
            // 
            // mailbox
            // 
            this.mailbox.Location = new System.Drawing.Point(51, 341);
            this.mailbox.Name = "mailbox";
            this.mailbox.PlaceholderText = "Emailová adresa";
            this.mailbox.Size = new System.Drawing.Size(210, 23);
            this.mailbox.TabIndex = 23;
            // 
            // phonebox
            // 
            this.phonebox.Location = new System.Drawing.Point(51, 312);
            this.phonebox.Name = "phonebox";
            this.phonebox.PlaceholderText = "Telefonní číslo";
            this.phonebox.Size = new System.Drawing.Size(145, 23);
            this.phonebox.TabIndex = 22;
            // 
            // lastnamebox
            // 
            this.lastnamebox.Location = new System.Drawing.Point(190, 283);
            this.lastnamebox.Name = "lastnamebox";
            this.lastnamebox.PlaceholderText = "Příjmení";
            this.lastnamebox.Size = new System.Drawing.Size(129, 23);
            this.lastnamebox.TabIndex = 21;
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(51, 283);
            this.namebox.Name = "namebox";
            this.namebox.PlaceholderText = "Jméno";
            this.namebox.Size = new System.Drawing.Size(118, 23);
            this.namebox.TabIndex = 20;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(513, 187);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // paybtn
            // 
            this.paybtn.Location = new System.Drawing.Point(148, 559);
            this.paybtn.Name = "paybtn";
            this.paybtn.Size = new System.Drawing.Size(99, 26);
            this.paybtn.TabIndex = 31;
            this.paybtn.Text = "zaplatit";
            this.paybtn.UseVisualStyleBackColor = true;
            this.paybtn.Click += new System.EventHandler(this.paybtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(40, 478);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 68);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Typ Dopravy:";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton3.Location = new System.Drawing.Point(22, 32);
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
            this.radioButton4.Location = new System.Drawing.Point(152, 32);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(69, 23);
            this.radioButton4.TabIndex = 16;
            this.radioButton4.Text = "Poštou";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 33;
            this.label1.Text = "Osobní údaje:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(51, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Provést platbu:";
            // 
            // EditObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 646);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.paybtn);
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
            this.Name = "EditObj";
            this.Text = "Editace objednávky";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox countrybox;
        private System.Windows.Forms.TextBox pscbox;
        private System.Windows.Forms.TextBox citybox;
        private System.Windows.Forms.TextBox streetbox;
        private System.Windows.Forms.TextBox mailbox;
        private System.Windows.Forms.TextBox phonebox;
        private System.Windows.Forms.TextBox lastnamebox;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button paybtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}