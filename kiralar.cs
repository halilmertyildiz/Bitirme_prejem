using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace proje
{
    public partial class kiralar : Form
    {
        public kiralar()
        {
            InitializeComponent();
        }

        private void kiralar_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde kiralanan araçları listele
            LoadKiralamaData();
        }

        private void LoadKiralamaData()
        {
            // Veritabanı bağlantı dizesi
            string connectionString = "server=localhost;database=proje;uid=root;pwd=123456;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Kiralanan araçlar ile ilgili sorgu
                    string query = @"
                        SELECT 
                            ka.kiralanan_araclar_id AS 'Kiralama ID',
                            k.k_ad AS 'Kullanıcı Adı',
                            CONCAT(k.isim, ' ', k.soyisim) AS 'Ad Soyad',
                            a.ad AS 'Araç Adı',
                            ka.kiralama_baslangic AS 'Başlangıç Tarihi',
                            ka.kiralama_bitis AS 'Bitiş Tarihi',
                            ka.toplam_ucret AS 'Toplam Ücret'
                        FROM 
                            kiralanan_araclar ka
                        INNER JOIN 
                            araclar a ON ka.arac_id = a.arac_id
                        INNER JOIN 
                            kullanicilar k ON ka.kullanici_id = k.id
                        ORDER BY 
                            ka.kiralanan_araclar_id DESC";

                    // Sorguyu çalıştır ve sonucu DataGridView'e yükle
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // DataGridView'e verileri bağla
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj göster
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tabloyu yenilemek için
            LoadKiralamaData();
        }
    }
}
