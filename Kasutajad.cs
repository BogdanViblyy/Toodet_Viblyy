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
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Toodet_Viblyy
{
    public partial class Kasutajad : Form
    {

        private string dbPath;
        private SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Administrator\Source\Repos\online-shop-windowsform-app\Toodet_Viblyy\AppData\Toodet_DB.mdf;Integrated Security = True;");
        
        public Kasutajad()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            InitializeComponent();
            
          
            NaitaKasutajad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                if (int.TryParse(textBox2.Text, out int boonus) && boonus <= 100 && boonus > 0)
                {
                    connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Administrator\Source\Repos\online-shop-windowsform-app\Toodet_Viblyy\AppData\Toodet_DB.mdf;Integrated Security = True;");

                    try
                    {
                        connect.Open();
                        SqlCommand command2 = new SqlCommand("INSERT INTO kliendidTabel(kasutajaId, boonus) VALUES (@id, @boonus)", connect);
                        command2.Parameters.AddWithValue("@id", Convert.ToInt32( textBox1.Text));
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
                // Вывод сообщения о незаполненных полях
                MessageBox.Show("Palun sisestaqe", "Tühjed väljed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            NaitaKasutajad();

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

 
        public void NaitaKasutajad()
        {
            using (connect)
            {
                connect.Open();
                DataTable dt_kas = new DataTable();
                SqlDataAdapter adapter_toode = new SqlDataAdapter("SELECT Kasutajatabel.id, Kasutajatabel.nimi, Kasutajatabel.rool FROM Kasutajatabel", connect);
                adapter_toode.Fill(dt_kas);
                dgwKas.DataSource = dt_kas;
            }
        }

        private void dgwKas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dgwKas.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Administrator\Source\Repos\online-shop-windowsform-app\Toodet_Viblyy\AppData\Toodet_DB.mdf;Integrated Security = True;");
            try
            {
                int id;
                int.TryParse(textBox1.Text, out id);              
                connect.Open();
                SqlCommand command2 = new SqlCommand("update Kasutajatabel set rool=1 where Id="+id, connect);

                command2.ExecuteNonQuery();
            }
            finally
            {
                connect.Close();
            }
            MessageBox.Show("Lasutaja on tehtud omaniku");
            NaitaKasutajad();

        }
    }
}
