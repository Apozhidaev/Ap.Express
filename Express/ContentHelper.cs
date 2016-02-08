using System.Security.Cryptography;
using System.Text;

namespace Express
{
    internal static class ContentHelper
    {
        public static string GetETag(this byte[] input)
        {
            using (var sha = SHA1.Create())
            {
                byte[] hash = sha.ComputeHash(input);
                var eTag = new StringBuilder();
                eTag.Append("\"");
                foreach (var c in hash)
                {
                    eTag.Append(c.ToString("x2"));
                }
                eTag.Append("\"");
                return eTag.ToString();
            }
        }
    }
}