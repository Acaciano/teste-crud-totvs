using System.Security.Cryptography;
using System.Text;

namespace Cbyk.ATS.API.Extension
{
    public static class HelperExtension
    {
        public static string GetSha1Hash(this string value)
        {
            var hasher = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(value);

            array = hasher.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
