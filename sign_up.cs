using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje
{ 

     public partial class sign_up : Form
    {

    static public string username {  get; set; }

    static public string password { get; set; }

    static public string isim { get; set; }

    static public string soyisim { get; set; }

    static public string email { get; set; }

    public sign_up()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isim = textBox2.Text;
            string soyisim = textBox4.Text;
            string username = textBox1.Text;
            string password = textBox3.Text;
            string email = textBox5.Text;

            mail_doğrulama mailcheck = new mail_doğrulama();
            mailcheck.Show();
            
            MySqlConnection baglan = new MySqlConnection(
            "server=localhost;" +
            "database=proje;" +
            "user=root;" +
            "password=123456"
            );

            try
            {
                baglan.Open();
                string sql = "insert into kullanicilar(isim,soyisim,k_ad,sifre,mail) " +
                    "values(@isim , @soyisim , @username , @password , @mail)";

                MySqlCommand cmd = new MySqlCommand(sql, baglan);

                // Parametreler atandı
                cmd.Parameters.AddWithValue("@isim", isim);
                cmd.Parameters.AddWithValue("@soyisim", soyisim);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@mail", email);

                // Sorgu çalıştırılıyor
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            mail_doğrulama f2 = new mail_doğrulama();
            f2.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "username";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "password")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.White;
                textBox3.PasswordChar = '*';
            }
        }

        char? none = null;
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "password";
                textBox3.ForeColor = Color.Silver;
                textBox3.PasswordChar = Convert.ToChar(none);
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "isim")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "isim";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "soyisim")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.White;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "soyisim";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "email")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.White;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "email";
                textBox5.ForeColor = Color.Silver;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
