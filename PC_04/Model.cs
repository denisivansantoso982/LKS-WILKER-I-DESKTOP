using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PC_04
{
    class PegawaiModel
    {
        public static int id { get; set; }
        public static string nama { get; set; }
        public static string email { get; set; }
        public static string password { get; set; }
        public static int level { get; set; }
    }

    class Encryption
    {
        public static string encryptData(string data)
        {
            using (SHA256Managed managed = new SHA256Managed())
            {
                byte[] str_data = Encoding.UTF8.GetBytes(data);
                var encrypt_result = managed.ComputeHash(str_data);
                string result = Convert.ToBase64String(encrypt_result);

                return result;
            }
        }
    }

    class ColourModel
    {
        public static Color primary = Color.FromArgb(4, 124, 204);
        public static Color secondary = Color.FromArgb(15, 155, 244);
    }
}
