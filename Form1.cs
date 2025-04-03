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

       

     

    
        SqlDataAdapter adapter_toode, adapter_kategooria,adapter_pilt;
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
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            connect = new SqlConnection(connectionString);

            NaitaAndmed();
            NaitaKategooriaD();



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
            //    Kat_box.Items.Clear();
            //    Kat_box.Text = "";
            //    connect.Open();
            //    adapter_kategooria = new SqlDataAdapter("SELECT Id, Kategooria_nimetus FROM Kategooriatabel", connect);
            //    DataTable dt_kat = new DataTable();
            //    adapter_kategooria.Fill(dt_kat);
            //    foreach (DataRow item in dt_kat.Rows)
            //    {
            //        if (!Kat_box.Items.Contains(item["Kategooria_nimetus"]))
            //            Kat_box.Items.Add(item["Kategooria_nimetus"]);
            //        else
            //        {
            //            command = new SqlCommand("DELETE FROM Kategooriatabel WHERE Id=@Id", connect);
            //            command.Parameters.AddWithValue("@Id", item["Id"]);
            //            command.ExecuteNonQuery();
            //        }
            //    }
            //    connect.Close();
            //}



        //public void Lisa_Toode_btn_click(object sender, EventArgs e)
        //{
        //    if (textBox_hind.Text.Trim() != string.Empty && textBox_toode.Text.Trim() != string.Empty && textBox_kogus.Text.Trim() != string.Empty)
        //    {
        //        try
        //        {



        //        command = new SqlCommand("insert into Toodetabel(ToodeNimetus,Kogus,Hind,Kategooriat) values(@tod_nim,@kogus,@hind,@kat)", connect);
        //        connect.Open();
        //        command.Parameters.AddWithValue("@tod_nim", textBox_toode.Text);

        //        command.Parameters.AddWithValue("@kogus", textBox_kogus.Text);

        //        command.Parameters.AddWithValue("@hind", textBox_hind.Text);

        //        command.Parameters.AddWithValue("@kat", Kat_box.Text);
        //        command.ExecuteNonQuery();
        //        connect.Close();
        //        Kat_box.Items.Clear();
        //        textBox_toode.Clear();
        //        textBox_hind.Clear();
        //        textBox_kogus.Clear();
        //        InitializeComponent();
        //        NaitaAndmed();
        //        }
        //        catch (Exception)
        //        {

        //            MessageBox.Show("Andmebaasiga viga!");
        //        }
        //    }


        //}


        private void Kat_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//lisamine
        {
            if (textBox_hind.Text.Trim() != string.Empty && textBox_toode.Text.Trim() != string.Empty && textBox_kogus.Text.Trim() != string.Empty&&Kat_box.SelectedItem!=null)
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

                    command.Parameters.AddWithValue("@kat", Id);//id?!!!!!!!!!!!
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
            Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            if (textBox_hind.Text.Trim() != string.Empty && textBox_toode.Text.Trim() != string.Empty && textBox_kogus.Text.Trim() != string.Empty && Kat_box.SelectedItem != null)
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

                    command.Parameters.AddWithValue("@pilt", textBox_hind.Text + ".jpg");

                    command.Parameters.AddWithValue("@kat", Kat_box.SelectedIndex + 1);//id?!!!!!!!!!!!

                    command.Parameters.AddWithValue("@id",Id);
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

            //FileInfo open_info = new FileInfo(@"C:\Users\opilane\Pictures\" + open.FileName);

            if (open.ShowDialog() == DialogResult.OK && textBox_toode.Text != null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\pildid");

                extension = Path.GetExtension(open.FileName);
                save.FileName = textBox_toode.Text + Path.GetExtension(open.FileName);//extension
                save.Filter = "pildid" + Path.GetExtension(open.FileName) + "|" + Path.GetExtension(open.FileName);
                if (save.ShowDialog() == DialogResult.OK && textBox_toode.Text != null)
                {

                    File.Copy(open.FileName, save.FileName);//??
                    pictureBox_Toode.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus või oli vajutatud Cancel");
            }



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

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
                pictureBox_Toode.Image = Image.FromFile(@"..\..\pildid\ePood.png");


            }
            Kat_box.SelectedItem= dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_eemalda_Click(object sender, EventArgs e)
        {
            Eemalda();
        }

        private void pictureBox_Toode_Click(object sender, EventArgs e)
        {

        }

        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT Toodetabel.Id,Toodetabel.Toodenimetus,Toodetabel.Kogus,Toodetabel.Hind,Toodetabel.Pilt, Kategooriatabel.Kategooria_nimetus as Kategooria_nimetus  FROM Toodetabel INNER JOIN Kategooriatabel on Toodetabel.Kategooriat=Kategooriatabel.Id ", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat= new DataGridViewComboBoxColumn();
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
            pictureBox_Toode.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\pildid"), "ePood.png"));
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

        private void button1_Click_1(object sender, EventArgs e)//kustuta kategooria
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
