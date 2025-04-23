using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace Toodet_Viblyy
{
    public partial class Tsekk : Form
    {


        string path,nimi;
        public Tsekk(string filePath , string nim)
        {

            


            InitializeComponent();
           

            DateTime aeg = DateTime.Now;

            aeglbl.Text = aeg.ToString();


            path = filePath;

            nimi = nim;

            button1Fail.Text = nimi;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Faili ei leitud: " + path, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
