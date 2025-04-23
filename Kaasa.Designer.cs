namespace Toodet_Viblyy
{
    partial class Kaasa
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxToodet = new System.Windows.Forms.ListBox();
            this.Kat_box = new System.Windows.Forms.ComboBox();
            this.btnOstukorvile = new System.Windows.Forms.Button();
            this.btnMaksma = new System.Windows.Forms.Button();
            this.btnToode = new System.Windows.Forms.Button();
            this.lblSumma = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTervitamine = new System.Windows.Forms.Label();
            this.listBoxOstukorv = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonArvuta = new System.Windows.Forms.Button();
            this.labellll = new System.Windows.Forms.Label();
            this.labelHind = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listBoonused = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelKogus2 = new System.Windows.Forms.Label();
            this.pictureBox_Toode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Toode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(676, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kassa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(12, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tooted";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(689, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ostukorv";
            // 
            // listBoxToodet
            // 
            this.listBoxToodet.FormattingEnabled = true;
            this.listBoxToodet.Location = new System.Drawing.Point(12, 158);
            this.listBoxToodet.Name = "listBoxToodet";
            this.listBoxToodet.Size = new System.Drawing.Size(260, 121);
            this.listBoxToodet.TabIndex = 23;
            this.listBoxToodet.SelectedIndexChanged += new System.EventHandler(this.listBoxToodet_SelectedIndexChanged);
            // 
            // Kat_box
            // 
            this.Kat_box.FormattingEnabled = true;
            this.Kat_box.Location = new System.Drawing.Point(96, 131);
            this.Kat_box.Name = "Kat_box";
            this.Kat_box.Size = new System.Drawing.Size(120, 21);
            this.Kat_box.TabIndex = 25;
            this.Kat_box.SelectedIndexChanged += new System.EventHandler(this.Kat_box_SelectedIndexChanged);
            // 
            // btnOstukorvile
            // 
            this.btnOstukorvile.Location = new System.Drawing.Point(427, 158);
            this.btnOstukorvile.Name = "btnOstukorvile";
            this.btnOstukorvile.Size = new System.Drawing.Size(75, 23);
            this.btnOstukorvile.TabIndex = 26;
            this.btnOstukorvile.Text = ">";
            this.btnOstukorvile.UseVisualStyleBackColor = true;
            this.btnOstukorvile.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMaksma
            // 
            this.btnMaksma.Location = new System.Drawing.Point(643, 415);
            this.btnMaksma.Name = "btnMaksma";
            this.btnMaksma.Size = new System.Drawing.Size(145, 23);
            this.btnMaksma.TabIndex = 29;
            this.btnMaksma.Text = "Maksma";
            this.btnMaksma.UseVisualStyleBackColor = true;
            this.btnMaksma.Click += new System.EventHandler(this.btnMaksma_Click);
            // 
            // btnToode
            // 
            this.btnToode.Location = new System.Drawing.Point(12, 99);
            this.btnToode.Name = "btnToode";
            this.btnToode.Size = new System.Drawing.Size(145, 23);
            this.btnToode.TabIndex = 31;
            this.btnToode.Text = "Toodet";
            this.btnToode.UseVisualStyleBackColor = true;
            this.btnToode.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblSumma
            // 
            this.lblSumma.AutoSize = true;
            this.lblSumma.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lblSumma.Location = new System.Drawing.Point(379, 399);
            this.lblSumma.Name = "lblSumma";
            this.lblSumma.Size = new System.Drawing.Size(0, 39);
            this.lblSumma.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label6.Location = new System.Drawing.Point(345, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 26);
            this.label6.TabIndex = 35;
            this.label6.Text = "Summa";
            // 
            // lblTervitamine
            // 
            this.lblTervitamine.AutoSize = true;
            this.lblTervitamine.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lblTervitamine.Location = new System.Drawing.Point(12, 5);
            this.lblTervitamine.Name = "lblTervitamine";
            this.lblTervitamine.Size = new System.Drawing.Size(0, 39);
            this.lblTervitamine.TabIndex = 36;
            // 
            // listBoxOstukorv
            // 
            this.listBoxOstukorv.FormattingEnabled = true;
            this.listBoxOstukorv.Location = new System.Drawing.Point(524, 158);
            this.listBoxOstukorv.Name = "listBoxOstukorv";
            this.listBoxOstukorv.Size = new System.Drawing.Size(264, 121);
            this.listBoxOstukorv.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonArvuta
            // 
            this.buttonArvuta.Location = new System.Drawing.Point(350, 347);
            this.buttonArvuta.Name = "buttonArvuta";
            this.buttonArvuta.Size = new System.Drawing.Size(59, 23);
            this.buttonArvuta.TabIndex = 39;
            this.buttonArvuta.Text = "Arvuta";
            this.buttonArvuta.UseVisualStyleBackColor = true;
            this.buttonArvuta.Click += new System.EventHandler(this.buttonArvuta_Click);
            // 
            // labellll
            // 
            this.labellll.AutoSize = true;
            this.labellll.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labellll.Location = new System.Drawing.Point(275, 215);
            this.labellll.Name = "labellll";
            this.labellll.Size = new System.Drawing.Size(57, 26);
            this.labellll.TabIndex = 40;
            this.labellll.Text = "Hind";
            this.labellll.Click += new System.EventHandler(this.label4_Click);
            // 
            // labelHind
            // 
            this.labelHind.AutoSize = true;
            this.labelHind.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelHind.Location = new System.Drawing.Point(345, 215);
            this.labelHind.Name = "labelHind";
            this.labelHind.Size = new System.Drawing.Size(0, 26);
            this.labelHind.TabIndex = 41;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 23);
            this.button2.TabIndex = 42;
            this.button2.Text = "Kliendid";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBoonused
            // 
            this.listBoonused.FormattingEnabled = true;
            this.listBoonused.Location = new System.Drawing.Point(503, 415);
            this.listBoonused.Name = "listBoonused";
            this.listBoonused.Size = new System.Drawing.Size(120, 21);
            this.listBoonused.TabIndex = 43;
            this.listBoonused.SelectedIndexChanged += new System.EventHandler(this.listBoonused_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.Location = new System.Drawing.Point(498, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 26);
            this.label4.TabIndex = 44;
            this.label4.Text = "Boonused";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label5.Location = new System.Drawing.Point(275, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 26);
            this.label5.TabIndex = 45;
            this.label5.Text = "Olemas";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // labelKogus2
            // 
            this.labelKogus2.AutoSize = true;
            this.labelKogus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelKogus2.Location = new System.Drawing.Point(370, 268);
            this.labelKogus2.Name = "labelKogus2";
            this.labelKogus2.Size = new System.Drawing.Size(0, 26);
            this.labelKogus2.TabIndex = 46;
            // 
            // pictureBox_Toode
            // 
            this.pictureBox_Toode.Location = new System.Drawing.Point(39, 311);
            this.pictureBox_Toode.Name = "pictureBox_Toode";
            this.pictureBox_Toode.Size = new System.Drawing.Size(195, 125);
            this.pictureBox_Toode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Toode.TabIndex = 50;
            this.pictureBox_Toode.TabStop = false;
            // 
            // Kaasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox_Toode);
            this.Controls.Add(this.labelKogus2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoonused);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelHind);
            this.Controls.Add(this.labellll);
            this.Controls.Add(this.buttonArvuta);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxOstukorv);
            this.Controls.Add(this.lblTervitamine);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSumma);
            this.Controls.Add(this.btnToode);
            this.Controls.Add(this.btnMaksma);
            this.Controls.Add(this.btnOstukorvile);
            this.Controls.Add(this.Kat_box);
            this.Controls.Add(this.listBoxToodet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Kaasa";
            this.Text = "Kaasa";
            this.Load += new System.EventHandler(this.Kaasa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Toode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxToodet;
        private System.Windows.Forms.ComboBox Kat_box;
        private System.Windows.Forms.Button btnOstukorvile;
        private System.Windows.Forms.Button btnMaksma;
        private System.Windows.Forms.Button btnToode;
        private System.Windows.Forms.Label lblSumma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTervitamine;
        private System.Windows.Forms.ListBox listBoxOstukorv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonArvuta;
        private System.Windows.Forms.Label labellll;
        private System.Windows.Forms.Label labelHind;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox listBoonused;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelKogus2;
        private System.Windows.Forms.PictureBox pictureBox_Toode;
    }
}