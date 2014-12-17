using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Examiner_Pro.Utils
{
    public class Security
    {
        public static String GetHash(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            var hashedPassword = Convert.ToBase64String(md5data);
            return hashedPassword;
        }
    }
}
