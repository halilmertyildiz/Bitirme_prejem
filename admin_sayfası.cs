using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace proje
{
    public partial class AdminSayfasi : Form
    {
        private string connectionString = "Server=localhost;Database=proje;Uid=root;Pwd=123456;";

        public AdminSayfasi()
        {
            InitializeComponent();
        }

        private void AdminSayfasi_Load(object sender, EventArgs e)
        {
            AraclariListele();
        }

        private void AraclariListele()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT arac_id AS 'ID', ad AS 'Araç Adı', fiyat AS 'Fiyat' FROM araclar;";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonYenile_Click(object sender, EventArgs e)
        {
            AraclariListele();
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir araç seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int aracId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            string aracAdi = selectedRow.Cells["Araç Adı"].Value.ToString();
            string yeniFiyatStr = Microsoft.VisualBasic.Interaction.InputBox(
                $"Araç Adı: {aracAdi}\nMevcut Fiyat: {selectedRow.Cells["Fiyat"].Value}\nYeni fiyatı giriniz:",
                "Fiyat Güncelle",
                "");

            if (decimal.TryParse(yeniFiyatStr, out decimal yeniFiyat))
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE araclar SET fiyat = @yeniFiyat WHERE arac_id = @aracId;";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@yeniFiyat", yeniFiyat);
                            cmd.Parameters.AddWithValue("@aracId", aracId);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Fiyat başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AraclariListele(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir fiyat giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ANA_sayfa aNA_Sayfa = new ANA_sayfa();
            aNA_Sayfa.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            kiralar kiralar = new kiralar();
            kiralar.Show(); 
        }
    }
}
