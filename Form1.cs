using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection(
              "server=localhost;" +
              "database=proje;" +
              "user=root;" +
              "password=123456"
                );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sign_up f2 = new sign_up();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sign_in f2 = new sign_in();
            f2.Show();
        }
    }
}
