using System;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace proje
{
    public partial class mail_doğrulama : Form
    {

        static Random random = new Random();
        int rand_code = random.Next(1000, 9999);
        public mail_doğrulama()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "verification code")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "verification code";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void sendmail()
        {

            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();

            client.Credentials = new NetworkCredential("starmerthalil2@gmail.com" , "zksc qqxu xsmc iqmk");

            client.Port = 587;
            client.Host = "smtp.gmail.com"; // gmail için ayar yapman lazım.
            client.EnableSsl = true;

            message.To.Add(sign_up.email);
            message.From = new MailAddress("starmerthalil2@gmail.com");
            message.Subject = "registration verification";
            message.Body = "your verification code =" + rand_code;
            client.Send(message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == rand_code.ToString())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("something went wrong", "prgrom");
            }
        }

        private void mail_doğrulama_Load(object sender, EventArgs e)
        {
            sendmail();
        }
    }
}
