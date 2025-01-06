using System;
using System.Windows.Forms;

namespace proje
{
    public partial class ANA_sayfa : Form
    {
        public ANA_sayfa()
        {
            InitializeComponent();
        }

        private void ANA_sayfa_Load(object sender, EventArgs e)
        {
            // Sayfa yüklendiğinde kullanıcı giriş durumuna göre butonları ayarla
            KullaniciDurumunuGuncelle();
        }

        private void KullaniciDurumunuGuncelle()
        {
            if (Session.IsLoggedIn) // Kullanıcı giriş yaptıysa
            {
                label2.Text = $"{Session.Username}";
                label2.Visible = true;  // Kullanıcı adı göster
                button6.Visible = true; // Çıkış butonu göster
                button1.Visible = false; // Kayıt ol butonu gizle
                button2.Visible = false; // Giriş yap butonu gizle
            }
            else // Kullanıcı giriş yapmadıysa
            {
                label2.Text = string.Empty;
                label2.Visible = false; // Kullanıcı adı gizle
                button6.Visible = false; // Çıkış butonu gizle
                button1.Visible = true;  // Kayıt ol butonu göster
                button2.Visible = true;  // Giriş yap butonu göster
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kayıt ol butonu
            sign_up kayıtOl = new sign_up();
            kayıtOl.Show();
            this.Hide(); // Ana sayfayı gizle
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Giriş yap butonu
            sign_in girisYap = new sign_in();
            girisYap.Show();
            this.Hide(); // Ana sayfayı gizle
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Çıkış yap butonu
            Session.IsLoggedIn = false;
            Session.Username = string.Empty;

            MessageBox.Show("Başarıyla çıkış yaptınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KullaniciDurumunuGuncelle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vw_golf vwGolf = new vw_golf();
            vwGolf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            vw_polo vwPolo = new vw_polo();
            vwPolo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SEAT_LEON sEAT_LEON = new SEAT_LEON();
            sEAT_LEON.Show();
        }
    }
}
