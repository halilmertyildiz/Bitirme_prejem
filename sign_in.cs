using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace proje
{




    public partial class sign_in : Form
    {
        public sign_in()
        {
            InitializeComponent();
        }

        // Placeholder temizleme
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "username";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "password";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = '\0';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            using (MySqlConnection baglan = new MySqlConnection("server=localhost;database=proje;user=root;password=123456"))
            {
                try
                {
                    baglan.Open();

                    // Kullanıcı doğrulama sorgusu
                    string sql = "SELECT id, k_ad, rol FROM kullanicilar WHERE k_ad = @username AND sifre = @password;";
                    MySqlCommand komut = new MySqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@username", username);
                    komut.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = komut.ExecuteReader())
                    {
                        if (reader.Read()) // Kullanıcı bulunduysa
                        {
                            // Kullanıcı bilgilerini oturum değişkenlerine kaydet
                            Session.userid = reader.GetInt32("id"); // Kullanıcı ID'si
                            Session.Username = reader.GetString("k_ad"); // Kullanıcı adı
                            Session.IsLoggedIn = true;

                            string userRole = reader.GetString("rol"); // Kullanıcı rolü
                            MessageBox.Show($"Giriş başarılı!\nKullanıcı: {Session.Username}\nRol: {userRole}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Rolüne göre yönlendirme
                            if (userRole == "admin")
                            {
                                AdminSayfasi adminSayfasi = new AdminSayfasi();
                                adminSayfasi.Show();
                            }
                            else
                            {
                                ANA_sayfa anaSayfa = new ANA_sayfa();
                                anaSayfa.Show();
                            }

                            this.Hide(); // Giriş formunu gizle
                        }
                        else
                        {
                            MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }

