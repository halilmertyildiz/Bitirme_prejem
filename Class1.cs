using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje
{
    internal class Class1
    {
        internal class Session
        {
            public static bool IsLoggedIn { get; set; } = false; // Kullanıcının giriş durumu
            public static string Username { get; set; } = string.Empty; // Kullanıcı adı
            public static int userid { get; set; }
            public static string Role { get; set; } // Kullanıcı Rolü
        }

        public partial class MainForm : Form
        {
            private string username; // Global olarak tanımlandı
        }


    }
}
