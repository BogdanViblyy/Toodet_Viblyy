using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Toodet_Viblyy
{
    public partial class Kasutajad : Form
    {
        private SqlConnection connect;

        public Kasutajad()
        {
            InitializeComponent();
            ApplyDarkTheme();

            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            connect = new SqlConnection(connectionString);

            NaitaKasutajad();
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;

            textBox1.BackColor = Color.FromArgb(45, 45, 45);
            textBox1.ForeColor = Color.White;
            textBox1.BorderStyle = BorderStyle.FixedSingle;

            textBox2.BackColor = Color.FromArgb(45, 45, 45);
            textBox2.ForeColor = Color.White;
            textBox2.BorderStyle = BorderStyle.FixedSingle;

            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.Gray;

            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.Gray;

            dgwKas.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgwKas.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgwKas.DefaultCellStyle.ForeColor = Color.White;
            dgwKas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dgwKas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgwKas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 55, 55);
            dgwKas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgwKas.EnableHeadersVisualStyles = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                if (int.TryParse(textBox2.Text, out int boonus) && boonus <= 100 && boonus > 0)
                {
                    try
                    {
                        connect.Open();
                        SqlCommand command2 = new SqlCommand("INSERT INTO kliendidTabel(kasutajaId, boonus) VALUES (@id, @boonus)", connect);
                        command2.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
                        command2.Parameters.AddWithValue("@boonus", boonus);

                        command2.ExecuteNonQuery();
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Palun sisestage % boonus (1-100)", "Vale boonus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Palun sisestage kõik väljad", "Tühjad väljad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            NaitaKasutajad();
        }

        public void NaitaKasutajad()
        {
            try
            {
                connect.Open();
                DataTable dt_kas = new DataTable();
                SqlDataAdapter adapter_toode = new SqlDataAdapter("SELECT id, nimi, rool FROM Kasutajatabel", connect);
                adapter_toode.Fill(dt_kas);
                dgwKas.DataSource = dt_kas;
            }
            finally
            {
                connect.Close();
            }
        }

        private void dgwKas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dgwKas.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(textBox1.Text, out id);

                connect.Open();
                SqlCommand command2 = new SqlCommand("UPDATE Kasutajatabel SET rool=1 WHERE id=@id", connect);
                command2.Parameters.AddWithValue("@id", id);

                command2.ExecuteNonQuery();
            }
            finally
            {
                connect.Close();
            }

            MessageBox.Show("Kasutaja on nüüd omanik");
            NaitaKasutajad();
        }
    }
}
