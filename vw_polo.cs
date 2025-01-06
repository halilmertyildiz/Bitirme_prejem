using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace proje
{
    public partial class vw_polo : Form
    {
        private decimal fiyat; // Araç fiyatını tutmak için değişken
        private const int SigortaUcreti = 800; // Sigorta ücreti sabit değer

        public vw_polo()
        {
            InitializeComponent();
        }

        private void vw_polo_load(object sender, EventArgs e)
        {
            // Başlangıçta sigorta var olarak ayarlıyoruz
            radioButton1.Checked = true;

            // Fiyatı sabit olarak belirliyoruz
            fiyat = 600; // Fiyat sabit, veritabanı kullanmıyorsak buradaki değeri değiştirebilirsiniz
        }

        // Kiralama ücretini hesaplayan metod
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        // RadioButton'lar değiştiğinde fiyatı güncelleyen metod
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice(); // Sigorta var ya da yok değiştiğinde fiyatı güncelle
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice(); // Sigorta var ya da yok değiştiğinde fiyatı güncelle
        }

        // Fiyat hesaplamalarını yapan metod
        private void UpdateTotalPrice()
        {
            // Eğer gün sayısı geçerli bir sayıysa
            if (int.TryParse(textBox1.Text, out int gunSayisi) && gunSayisi > 0)
            {
                decimal toplam = fiyat * gunSayisi;

                // Sigorta varsa
                if (radioButton1.Checked)
                {
                    toplam += SigortaUcreti * gunSayisi;
                }

                // Sigorta yoksa
                if (radioButton2.Checked)
                {
                    toplam += 0; // Sigorta yok, ek ücret eklenmez
                }

                // Toplam fiyatı textbox2'ye yazdırıyoruz
                textBox2.Text = toplam.ToString("C"); // C: Para birimi formatı
            }
            else
            {
                textBox2.Clear(); // Geçersiz değer girildiğinde fiyatı temizle
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close(); // Formu kapat
        }
        // Bu metod fiyatı veritabanından alır

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("Lütfen giriş yapınız.");
                return;
            }

            try
            {
                int kullaniciId = Session.userid; // Oturum açmış kullanıcının ID'si
                int aracId = 2; // Örnek: golf araç ID'si
                DateTime baslangicTarihi = DateTime.Now; // Kiralama başlangıç tarihi
                int gunSayisi = int.Parse(textBox1.Text); // Kullanıcının girdiği gün sayısı
                DateTime bitisTarihi = baslangicTarihi.AddDays(gunSayisi);
                decimal toplamUcret = fiyat * gunSayisi;

                if (radioButton1.Checked) // Sigorta eklenmişse
                {
                    toplamUcret += SigortaUcreti * gunSayisi;
                }

                string connectionString = "Server=localhost;Database=proje;Uid=root;Pwd=123456;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                INSERT INTO kiralanan_araclar (kullanici_id, arac_id, kiralama_baslangic, kiralama_bitis, toplam_ucret)
                VALUES (@kullaniciId, @aracId, @baslangic, @bitis, @toplamUcret);";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId); // Kullanıcı ID'si
                        cmd.Parameters.AddWithValue("@aracId", aracId);          // Araç ID'si
                        cmd.Parameters.AddWithValue("@baslangic", baslangicTarihi);
                        cmd.Parameters.AddWithValue("@bitis", bitisTarihi);
                        cmd.Parameters.AddWithValue("@toplamUcret", toplamUcret);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Araç başarıyla kiralandı!");
                        }
                        else
                        {
                            MessageBox.Show("Araç kiralanırken bir hata oluştu.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
