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
            KullaniciDurumunuGuncelle();
        }

        private void KullaniciDurumunuGuncelle()
        {
            if (Session.IsLoggedIn) 
            {
                label2.Text = $"{Session.Username}";
                label2.Visible = true; 
                button6.Visible = true;
                button1.Visible = false; 
                button2.Visible = false; 
            }
            else 
            {
                label2.Text = string.Empty;
                label2.Visible = false;
                button6.Visible = false; 
                button1.Visible = true;  
                button2.Visible = true;  
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sign_up kayıtOl = new sign_up();
            kayıtOl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sign_in girisYap = new sign_in();
            girisYap.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
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
