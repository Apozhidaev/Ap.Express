using System.Security.Cryptography;
using System.Text;

namespace Ap.Express
{
    public static class HashHelper
    {
        public static string GetSHA1(this byte[] input)
        {
            using (var sha = SHA1.Create())
            {
                byte[] data = sha.ComputeHash(input);
                return data.ToHex();
            }
        }

        public static string ToHex(this byte[] data)
        {
            var str = new StringBuilder();
            foreach (var b in data)
            {
                str.Append(b.ToString("x2"));
            }
            return str.ToString();
        }
    }
}