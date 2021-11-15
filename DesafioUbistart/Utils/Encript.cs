using System.Security.Cryptography;
using System.Text;

namespace DesafioUbistart
{
    public static class Encript
    {
        public static string ToEncript(this string senha)
        {
            string valorRetorno;

            using (var hash = SHA1.Create())
            {
                var bytes = Encoding.ASCII.GetBytes(senha);
                var data = hash.ComputeHash(bytes);
                var s = new StringBuilder();

                foreach (byte t in data)
                {
                    s.Append(t.ToString("X2"));
                }
                valorRetorno = s.ToString();
            }
            return valorRetorno;
        }
    }
}
