using System.Drawing;
using System.Windows.Forms;
using System;

namespace Toodet_Viblyy
{
    partial class Registreerimine
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
            this.label4 = new Label();
            this.registration_button = new Button();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.namebox = new TextBox();
            this.txtParool = new TextBox();

            // Form settings
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(604, 321);
            this.Name = "Registreerimine";
            this.Text = "Registreerimine";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // label4 - Header
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            this.label4.Location = new Point(100, 20);
            this.label4.Name = "label4";
            this.label4.Size = new Size(420, 45);
            this.label4.Text = "Logi sisse / Registreeru";
            this.label4.ForeColor = Color.White;

            // label1 - Nimi
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            this.label1.Location = new Point(250, 80);
            this.label1.Name = "label1";
            this.label1.Text = "Nimi";
            this.label1.ForeColor = Color.White;

            // namebox
            this.namebox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.namebox.Location = new Point(210, 120);
            this.namebox.Name = "namebox";
            this.namebox.Size = new Size(180, 29);
            this.namebox.BackColor = Color.FromArgb(30, 30, 30);
            this.namebox.ForeColor = Color.White;
            this.namebox.BorderStyle = BorderStyle.FixedSingle;

            // label3 - Parool
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            this.label3.Location = new Point(245, 160);
            this.label3.Name = "label3";
            this.label3.Text = "Parool";
            this.label3.ForeColor = Color.White;

            // txtParool
            this.txtParool.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtParool.Location = new Point(210, 200);
            this.txtParool.Name = "txtParool";
            this.txtParool.Size = new Size(180, 29);
            this.txtParool.BackColor = Color.FromArgb(30, 30, 30);
            this.txtParool.ForeColor = Color.White;
            this.txtParool.BorderStyle = BorderStyle.FixedSingle;
            this.txtParool.PasswordChar = '*';

            // registration_button
            this.registration_button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.registration_button.Location = new Point(235, 250);
            this.registration_button.Name = "registration_button";
            this.registration_button.Size = new Size(130, 35);
            this.registration_button.Text = "Logi sisse";
            this.registration_button.BackColor = Color.FromArgb(50, 50, 50);
            this.registration_button.ForeColor = Color.White;
            this.registration_button.FlatStyle = FlatStyle.Flat;
            this.registration_button.FlatAppearance.BorderColor = Color.Gray;
            this.registration_button.Click += new EventHandler(this.registration_button_Click);

            // Add controls to the form
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtParool);
            this.Controls.Add(this.registration_button);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button registration_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.TextBox txtParool;
    }
}