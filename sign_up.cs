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

        private  void button1_Click(object sender, EventArgs e)
        {
                string isim = textBox2.Text.Trim();
                string soyisim = textBox4.Text.Trim();
                string username = textBox1.Text.Trim();
                string password = textBox3.Text.Trim();
                string email = textBox5.Text.Trim();

                MySqlConnection baglan = new MySqlConnection(
                    "server=localhost;" +
                    "database=proje;" +
                    "user=root;" +
                    "password=123456"
                );

                try
                {
                    baglan.Open();

                    
                    string sql = "INSERT INTO kullanicilar (isim, soyisim, k_ad, sifre, mail, rol) " +
                                 "VALUES (@isim, @soyisim, @username, @password, @mail, 'kullanici')";

                    using (MySqlCommand cmd = new MySqlCommand(sql, baglan))
                    {
                        cmd.Parameters.AddWithValue("@isim", isim);
                        cmd.Parameters.AddWithValue("@soyisim", soyisim);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password); 
                        cmd.Parameters.AddWithValue("@mail", email);

                        cmd.ExecuteNonQuery(); 
                    }

                    
                    DialogResult result = MessageBox.Show(
                        "Kayıt başarılı! Giriş formuna yönlendiriliyorsunuz.",
                        "Bilgi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    if (result == DialogResult.OK)
                    {
                        sign_in sign_İn = new sign_in(); 
                        sign_İn.Show(); 
                        this.Close(); 
                    }
                }
                catch (MySqlException ex) when (ex.Number == 1062)
                {
                    MessageBox.Show("Bu kullanıcı adı veya e-posta zaten kayıtlı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (baglan.State == System.Data.ConnectionState.Open)
                    {
                        baglan.Close();
                    }
                }
            


        }

        private void button1_Click1(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "kullanıcı adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "kullanıcı adı";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "şifre")
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
                textBox3.Text = "şifre";
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

        private void sign_up_Load(object sender, EventArgs e)
        {

        }
    }
}
