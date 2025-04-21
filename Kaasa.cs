using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toodet_Viblyy
{
    public partial class Kaasa : Form
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
        bool isOmanik;
        int summa;
        int kasutajaId;
        List<string> katNimetusList;
        string nimi;

        public Kaasa(string Nimi, bool IsOmanik, int kasId)
        {
            InitializeComponent();
            ApplyDarkTheme();

            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            connect = new SqlConnection(connectionString);
            mainPB.Image = Image.FromFile(@"..\..\pildid\ePood.png");
            mainPB.SizeMode = PictureBoxSizeMode.Zoom;

            nimi = Nimi;
            isOmanik = IsOmanik;
            kasutajaId = kasId;

            lblTervitamine.Text = "Tere, " + Nimi;
            lblSumma.Text = "0";
            Kat_box.Text = "Valitage kategooriat";

            if (isOmanik)
            {
                btnToode.Visible = true;
                button2.Visible = true;
            }
            else
            {
                btnToode.Visible = false;
                button2.Visible = false;
            }

            NaitaAndmed();
            calculateSum();
            NaitaBoonused(kasutajaId);
        }

        private void ApplyDarkTheme()
        {
            // Form styling
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            // ListBox styling
            listBoxToodet.BackColor = Color.FromArgb(45, 45, 45);
            listBoxToodet.ForeColor = Color.White;
            listBoxToodet.BorderStyle = BorderStyle.FixedSingle;

            listBoxOstukorv.BackColor = Color.FromArgb(45, 45, 45);
            listBoxOstukorv.ForeColor = Color.White;
            listBoxOstukorv.BorderStyle = BorderStyle.FixedSingle;

            // ComboBox styling
            Kat_box.BackColor = Color.FromArgb(70, 70, 70);
            Kat_box.ForeColor = Color.White;
            Kat_box.FlatStyle = FlatStyle.Flat;

            listBoonused.BackColor = Color.FromArgb(70, 70, 70);
            listBoonused.ForeColor = Color.White;
            listBoonused.FlatStyle = FlatStyle.Flat;

            // PictureBox styling
            mainPB.BackColor = Color.FromArgb(45, 45, 45);
            mainPB.BorderStyle = BorderStyle.FixedSingle;
            mainPB.SizeMode = PictureBoxSizeMode.Zoom;

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
                else if (control is Label)
                {
                    Label label = (Label)control;
                    label.ForeColor = Color.White;
                }
            }
        }

        public void calculateSum()
        {
            summa = 0;

            foreach (string item in listBoxOstukorv.Items)
            {
                connect.Open();
                SqlCommand command1 = new SqlCommand("SELECT Hind FROM Toodetabel WHERE ToodeNimetus = @item", connect);
                command1.Parameters.AddWithValue("@item", item);
                SqlDataReader reader = command1.ExecuteReader();

                while (reader.Read())
                {
                    int n;
                    if (int.TryParse(reader["Hind"].ToString(), out n))
                    {
                        summa += n;
                    }
                }

                reader.Close();
                connect.Close();
            }

            if (listBoonused.SelectedItem != null)
            {
                int selectedBoonusPercent = (int)listBoonused.SelectedItem;
                double bonusAmount = (double)summa * selectedBoonusPercent / 100;
                summa -= (int)bonusAmount;
            }

            lblSumma.Text = summa.ToString();
        }

        public void NaitaAndmed()
        {
            connect.Open();

            SqlCommand command1 = new SqlCommand("SELECT Kategooria_nimetus FROM Kategooriatabel", connect);
            SqlDataReader reader = command1.ExecuteReader();
            katNimetusList = new List<string>();

            while (reader.Read())
            {
                string katNimetus = reader["Kategooria_nimetus"].ToString();
                katNimetusList.Add(katNimetus);
            }

            reader.Close();
            connect.Close();

            foreach (string item in katNimetusList)
            {
                Kat_box.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxOstukorv.BeginUpdate();
            foreach (object Item in listBoxToodet.SelectedItems)
            {
                listBoxOstukorv.Items.Add(Item);
            }
            listBoxOstukorv.EndUpdate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void Kat_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            connect.Open();
            List<string> toodeNimetusList = new List<string>();

            int id = Kat_box.SelectedIndex + 12;
            SqlCommand command = new SqlCommand("SELECT ToodeNimetus,Kogus FROM Toodetabel where Kategooriat=" + id, connect);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string toodeNimetus = reader["ToodeNimetus"].ToString();
                int kogus = (int)reader["Kogus"];
                if (kogus > 0)
                {
                    toodeNimetusList.Add(toodeNimetus);
                }
            }

            reader.Close();
            connect.Close();

            listBoxToodet.Items.Clear();

            foreach (string item in toodeNimetusList)
            {
                listBoxToodet.Items.Add(item);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listBoxOstukorv.SelectedIndex != -1)
            {
                listBoxOstukorv.Items.RemoveAt(listBoxOstukorv.SelectedIndex);
            }
        }

        private void Kaasa_Load(object sender, EventArgs e) { }

        private void buttonArvuta_Click(object sender, EventArgs e)
        {
            calculateSum();
        }

        private void label4_Click(object sender, EventArgs e) { }

        private void listBoxToodet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxToodet.SelectedItem != null)
            {
                connect.Open();
                SqlCommand command1 = new SqlCommand("SELECT Hind,Kogus,Pilt FROM Toodetabel WHERE ToodeNimetus = @item", connect);
                command1.Parameters.AddWithValue("@item", listBoxToodet.SelectedItem.ToString());
                SqlDataReader reader = command1.ExecuteReader();

                while (reader.Read())
                {
                    int n;
                    if (int.TryParse(reader["Hind"].ToString(), out n))
                    {
                        labelHind.Text = n.ToString();
                        labelKogus2.Text = reader["Kogus"].ToString();
                    }

                    if (reader["Pilt"].ToString() != "")
                    {
                        try
                        {
                            pictureBox_Toode.Image = Image.FromFile(@"..\..\pildid\" + reader["Pilt"].ToString());
                        }
                        catch (Exception)
                        {
                            pictureBox_Toode.Image = null;
                        }
                    }
                    else
                    {
                        pictureBox_Toode.Image = null;
                    }
                }

                reader.Close();
                connect.Close();
            }
        }

        public void NaitaBoonused(int kasutajaId)
        {
            connect.Open();

            SqlCommand command1 = new SqlCommand("SELECT boonus FROM kliendidTabel WHERE kasutajaId=@id", connect);
            command1.Parameters.AddWithValue("@id", kasutajaId);
            SqlDataReader reader = command1.ExecuteReader();
            List<int> listBoonused1 = new List<int>();

            while (reader.Read())
            {
                int boonus = reader.GetInt32(reader.GetOrdinal("boonus"));
                listBoonused1.Add(boonus);
            }

            reader.Close();
            connect.Close();

            listBoonused.Items.Clear();

            foreach (int item in listBoonused1)
            {
                listBoonused.Items.Add(item);
            }
        }

        private void btnMaksma_Click(object sender, EventArgs e)
        {
            calculateSum();

            List<string> Toodet = new List<string>();
            List<int> Hinnad = new List<int>();

            foreach (string item in listBoxOstukorv.Items)
            {
                connect.Open();
                SqlCommand command1 = new SqlCommand("SELECT Hind FROM Toodetabel WHERE ToodeNimetus = @item", connect);
                command1.Parameters.AddWithValue("@item", item);
                SqlDataReader reader = command1.ExecuteReader();

                while (reader.Read())
                {
                    int hind;
                    if (int.TryParse(reader["Hind"].ToString(), out hind))
                    {
                        Hinnad.Add(hind);
                    }
                }

                reader.Close();
                connect.Close();

                Toodet.Add(item.ToString());
            }

            int Summa;
            int.TryParse(lblSumma.Text, out Summa);

            Kvitung kvitung = new Kvitung(Toodet, Hinnad, Summa);

            foreach (var item in listBoxOstukorv.Items)
            {
                RemoveProductFromDatabase(item.ToString(), 1);
            }

            listBoxOstukorv.Items.Clear();
        }

        private void RemoveProductFromDatabase(string productName, int quantity)
        {
            connect.Open();

            SqlCommand command = new SqlCommand("UPDATE Toodetabel SET Kogus = Kogus - @quantity WHERE ToodeNimetus = @productName", connect);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@productName", productName);

            command.ExecuteNonQuery();

            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kasutajad kas = new Kasutajad();
            kas.ShowDialog();
        }

        private void listBoonused_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateSum();
        }

        private void label5_Click(object sender, EventArgs e) { }

        private void label7_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }
    }
}