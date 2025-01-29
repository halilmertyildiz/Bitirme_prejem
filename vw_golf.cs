using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace proje
{
    public partial class vw_golf : Form
    {
        private decimal fiyat; 
        private const int SigortaUcreti = 700; 

        public vw_golf()
        {
            InitializeComponent();
        }

        private void vw_golf_Load(object sender, EventArgs e)
        {
           
            radioButton1.Checked = true;

           
            fiyat = 500; 
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice(); 
        }

       
        private void UpdateTotalPrice()
        {
           
            if (int.TryParse(textBox1.Text, out int gunSayisi) && gunSayisi > 0)
            {
                decimal toplam = fiyat * gunSayisi;

             
                if (radioButton1.Checked)
                {
                    toplam += SigortaUcreti * gunSayisi;
                }

           
                if (radioButton2.Checked)
                {
                    toplam += 0; 
                }

            
                textBox2.Text = toplam.ToString("C"); 
            }
            else
            {
                textBox2.Clear(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("Lütfen giriş yapınız.");
                return;
            }

            try
            {
                int kullaniciId = Session.userid; 
                int aracId = 3; 
                DateTime baslangicTarihi = DateTime.Now; 
                int gunSayisi = int.Parse(textBox1.Text); 
                DateTime bitisTarihi = baslangicTarihi.AddDays(gunSayisi);
                decimal toplamUcret = fiyat * gunSayisi;

                if (radioButton1.Checked)
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
                        cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId); 
                        cmd.Parameters.AddWithValue("@aracId", aracId);        
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
