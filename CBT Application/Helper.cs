using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CBT_Application
{
    internal class Helper
    {
        public static string GenerateHash256(string str)
        {
            string result = "";
            try
            {
                using (var sha = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(str);
                    byte[] hash = sha.ComputeHash(bytes);
                    result = Convert.ToBase64String(hash);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
