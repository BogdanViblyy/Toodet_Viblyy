using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toodet_Viblyy
{

    public partial class Registreerimine : Form
    {
        SqlDataAdapter adapter_toode, adapter_kategooria, adapter_pilt;
        SqlCommand command;
        OpenFileDialog open;
        SaveFileDialog save;
        private string dbPath;
        private SqlConnection connect;
       
        public Registreerimine()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            connect = new SqlConnection(connectionString);
        }

        private void registration_button_Click(object sender, EventArgs e)
        {
            bool isOmanik;
            if (!string.IsNullOrEmpty(namebox.Text) && !string.IsNullOrEmpty(txtParool.Text))
            {
                connect.Open();
                SqlCommand command1 = new SqlCommand("SELECT id, nimi, parool, rool FROM Kasutajatabel WHERE nimi = @nimi and parool = @parool", connect);
                command1.Parameters.AddWithValue("@nimi", namebox.Text);
                command1.Parameters.AddWithValue("@parool", txtParool.Text);
                SqlDataReader reader = command1.ExecuteReader();

                if (reader.Read())
                {
                    string nimi = reader["nimi"].ToString();
                    int rool = reader.GetInt32(reader.GetOrdinal("rool"));
                    if (rool == 1)
                    {
                        isOmanik = true;
                    }
                    else
                    {
                        isOmanik = false;
                    }

                    Kaasa kasa = new Kaasa(nimi, isOmanik, reader.GetInt32(reader.GetOrdinal("id")));
                    kasa.ShowDialog();
                }
                else
                {
                    reader.Close();

                    SqlCommand command2 = new SqlCommand("INSERT INTO Kasutajatabel(nimi, parool, rool) VALUES (@nimi, @parool, @rool)", connect);
                    command2.Parameters.AddWithValue("@nimi", namebox.Text);
                    command2.Parameters.AddWithValue("@parool", txtParool.Text);
                    command2.Parameters.AddWithValue("@rool", 0);

                    int rowsAffected = command2.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        reader = command1.ExecuteReader(); // Повторно выполняем запрос для получения идентификатора нового пользователя

                        if (reader.Read())
                        {
                            string nimi = reader["nimi"].ToString();
                            int rool = reader.GetInt32(reader.GetOrdinal("rool"));
                            if (rool == 1)
                            {
                                isOmanik = true;
                            }
                            else
                            {
                                isOmanik = false;
                            }

                            Kaasa kasa = new Kaasa(nimi, isOmanik, reader.GetInt32(reader.GetOrdinal("id")));
                            kasa.ShowDialog();
                        }
                    }
                }

                reader.Close(); 
                connect.Close(); 
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
