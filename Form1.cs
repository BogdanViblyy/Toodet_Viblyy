using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Toodet_Viblyy
{
    public partial class Form1 : Form
    {
        private string dbPath;
        private SqlConnection connect;
        SqlDataAdapter adapter_toode, adapter_kategooria, adapter_pilt;
        SqlCommand command;
        OpenFileDialog open;
        SaveFileDialog save;
        int Id;
        DataGridViewComboBoxColumn combo_kat;
        string extension = null;
        string connectionString;

        public Form1()
        {
            InitializeComponent();
            ApplyDarkTheme();
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            connect = new SqlConnection(connectionString);

            NaitaAndmed();
            NaitaKategooriaD();
        }

        private void ApplyDarkTheme()
        {
            // Form styling
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            // DataGridView styling
            dataGridView1.BackgroundColor = Color.FromArgb(45, 45, 45);
            dataGridView1.GridColor = Color.Gray;
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;

            // PictureBox styling
            pictureBox_Toode.BackColor = Color.FromArgb(45, 45, 45);
            pictureBox_Toode.BorderStyle = BorderStyle.FixedSingle;
            pictureBox_Toode.SizeMode = PictureBoxSizeMode.Zoom;

            // Buttons styling
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.BackColor = Color.FromArgb(70, 70, 70);
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Gray;
                }
                else if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.BackColor = Color.FromArgb(70, 70, 70);
                    textBox.ForeColor = Color.White;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.BackColor = Color.FromArgb(70, 70, 70);
                    comboBox.ForeColor = Color.White;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                else if (control is Label)
                {
                    Label label = (Label)control;
                    label.ForeColor = Color.White;
                }
            }
        }

        public void NaitaKategooriaD()
        {
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("SELECT Kategooria_nimetus from Kategooriatabel", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach (DataRow item in dt_kat.Rows)
            {
                Kat_box.Items.Add(item["Kategooria_nimetus"]);
            }
            connect.Close();
        }

        private void Kat_box_SelectedIndexChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)//lisamine
        {
            if (textBox_hind.Text.Trim() != string.Empty && textBox_toode.Text.Trim() != string.Empty && textBox_kogus.Text.Trim() != string.Empty && Kat_box.SelectedItem != null)
            {
                try
                {
                    connect.Open();

                    command = new SqlCommand("SELECT Id FROM Kategooriatabel WHERE Kategooria_nimetus=@kat", connect);
                    command.Parameters.AddWithValue("@kat", Kat_box.Text);
                    command.ExecuteNonQuery();
                    Id = Convert.ToInt32(command.ExecuteScalar());

                    command = new SqlCommand("insert into Toodetabel(ToodeNimetus,Kogus,Hind,Pilt,Kategooriat) values(@tod_nim,@kogus,@hind,@pilt,@kat)", connect);
                    command.Parameters.AddWithValue("@tod_nim", textBox_toode.Text);
                    command.Parameters.AddWithValue("@kogus", textBox_kogus.Text);
                    command.Parameters.AddWithValue("@hind", textBox_hind.Text);
                    command.Parameters.AddWithValue("@pilt", textBox_toode.Text + extension);
                    command.Parameters.AddWithValue("@kat", Id);
                    command.ExecuteNonQuery();
                    connect.Close();

                    NaitaAndmed();
                    Eemalda();
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Tühjed väljad");
            }
        }

        public void button_Kustuta_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            if (Id != 0)
            {
                command = new SqlCommand("DELETE Toodetabel WHERE Id=@id", connect);
                connect.Open();
                command.Parameters.AddWithValue("@id", Id);
                command.ExecuteNonQuery();
                connect.Close();

                NaitaAndmed();
                MessageBox.Show("Andmed tabelist Tooded on kustutatud");
                Eemalda();
            }
            else
            {
                MessageBox.Show("Viga Tooded tabelist andmete kustutamisega");
            }
        }

        private void button_Uuenda_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Palun vali rida, mida uuendada.");
                return;
            }

            Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            if (textBox_hind.Text.Trim() != string.Empty &&
                textBox_toode.Text.Trim() != string.Empty &&
                textBox_kogus.Text.Trim() != string.Empty &&
                Kat_box.SelectedItem != null)
            {
                try
                {
                    command = new SqlCommand("update Toodetabel " +
                        "set ToodeNimetus = @tod_nim, Kogus = @kogus, Hind = @hind, Pilt= @pilt, Kategooriat = @kat " +
                        "where Id=@id", connect);
                    connect.Open();
                    command.Parameters.AddWithValue("@tod_nim", textBox_toode.Text);
                    command.Parameters.AddWithValue("@kogus", textBox_kogus.Text);
                    command.Parameters.AddWithValue("@hind", textBox_hind.Text);
                    command.Parameters.AddWithValue("@pilt", textBox_toode.Text + extension);
                    command.Parameters.AddWithValue("@kat", Kat_box.SelectedIndex + 1);
                    command.Parameters.AddWithValue("@id", Id);
                    command.ExecuteNonQuery();
                    connect.Close();

                    NaitaAndmed();
                    Eemalda();
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Tühjad väljad!");
            }
        }

        private void otsi_file_button_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\opilane\pictures";
            open.Multiselect = true;
            open.Filter = "Images Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";

            if (open.ShowDialog() == DialogResult.OK && textBox_toode.Text != null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\pildid");

                extension = Path.GetExtension(open.FileName);
                save.FileName = textBox_toode.Text + Path.GetExtension(open.FileName);
                save.Filter = "pildid" + Path.GetExtension(open.FileName) + "|" + Path.GetExtension(open.FileName);
                if (save.ShowDialog() == DialogResult.OK && textBox_toode.Text != null)
                {
                    File.Copy(open.FileName, save.FileName);
                    pictureBox_Toode.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus või oli vajutatud Cancel");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) { }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            textBox_toode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox_kogus.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox_hind.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            try
            {
                pictureBox_Toode.Image = Image.FromFile(@"..\..\pildid\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Pilt puudub");
                pictureBox_Toode.Image = Image.FromFile(@"..\..\pildid\ePood.jpg");
            }
            Kat_box.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void button_eemalda_Click(object sender, EventArgs e)
        {
            Eemalda();
        }

        private void pictureBox_Toode_Click(object sender, EventArgs e) { }

        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT Toodetabel.Id,Toodetabel.Toodenimetus,Toodetabel.Kogus,Toodetabel.Hind,Toodetabel.Pilt, Kategooriatabel.Kategooria_nimetus as Kategooria_nimetus  FROM Toodetabel INNER JOIN Kategooriatabel on Toodetabel.Kategooriat=Kategooriatabel.Id ", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            combo_kat.DataPropertyName = "Kategooria_nimetus";
            HashSet<string> keys = new HashSet<string>();
            foreach (DataRow item in dt_toode.Rows)
            {
                string kat_n = item["Kategooria_nimetus"].ToString();
                if (!keys.Contains(kat_n))
                {
                    keys.Add(kat_n);
                    combo_kat.Items.Add(kat_n);
                }
            }
            dataGridView1.Columns.Add(combo_kat);
            pictureBox_Toode.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\pildid"), "ePood.jpg"));
            pictureBox_Toode.SizeMode = PictureBoxSizeMode.Zoom;
            connect.Close();
        }

        private void lisa_kat_butt_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach (var item in Kat_box.Items)
            {
                if (item.ToString() == Kat_box.Text)
                {
                    on = true;
                }
            }
            if (on == false)
            {
                command = new SqlCommand("insert into Kategooriatabel(Kategooria_nimetus) values(@kat)", connect);
                connect.Open();
                command.Parameters.AddWithValue("@kat", Kat_box.Text);
                command.ExecuteNonQuery();
                connect.Close();
                Kat_box.Items.Clear();
                NaitaKategooriaD();
                MessageBox.Show("Kategooria on lisatud");
            }
            else
            {
                MessageBox.Show("Selline kategooriat on juba olemas");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Kat_box.SelectedItem != null)
            {
                connect.Open();
                string kat_val = Kat_box.SelectedItem.ToString();
                command = new SqlCommand("DELETE FROM Kategooriatabel WHERE Kategooria_nimetus=@kat", connect);
                command.Parameters.AddWithValue("@kat", kat_val);
                try
                {
                    command.ExecuteNonQuery();
                    Kat_box.Text = null;
                    MessageBox.Show("Kategooria on kustatud");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ei saa kustuta kategooriat, milles on registreeritud tooded");
                }

                connect.Close();
                Kat_box.Items.Clear();
                NaitaKategooriaD();
            }
        }

        public void Eemalda()
        {
            textBox_hind.Clear();
            textBox_kogus.Clear();
            textBox_toode.Clear();
            pictureBox_Toode.Image = Image.FromFile(@"..\..\pildid\ePood.png");
            Kat_box.Text = null;
        }
    }
}