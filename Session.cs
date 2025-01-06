using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje
{
    internal class Session
    {
        public static bool IsLoggedIn { get; set; } = false; // Kullanıcının giriş durumu
        public static int userid { get; set; }
        public static string Username { get; set; } = string.Empty; // Kullanıcı adı
        public static string Role { get; set; } // Kullanıcı Rolü
    }
}
