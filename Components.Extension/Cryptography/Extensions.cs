using Components.Extension.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Components.Extension.Cryptography
{
    public static class Extensions
    {
        public static string Xor(this string value, string key)
        {
            value.NotNull("value");
            key.NotNull("key");

            var sb = new StringBuilder(value.Length);

            for (int i = 0; i < value.Length; ++i)
            {
                var ch = (char)((uint)value[i] ^ (uint)key[i % key.Length]);
                sb.Append(ch);
            }

            return sb.ToString();
        }

        public static string XorB64Encrypt(this string value, string key)
        {
            value.NotEmpty("value");
            key.NotEmpty("key");

            var enc = value.Xor(key);
            var bytes = Encoding.Default.GetBytes(enc);
            return Convert.ToBase64String(bytes);
        }

        public static string XorB64Decrypt(this string value, string key)
        {
            value.NotEmpty("value");
            key.NotEmpty("key");

            var bytes = Convert.FromBase64String(value);
            var enc = Encoding.Default.GetString(bytes);
            return enc.Xor(key);
        }

        public static string MD5(this string value)
        {
            using (var algo = MD5CryptoServiceProvider.Create())
            {
                var buf = algo.ComputeHash(Encoding.Default.GetBytes(value));
                var sb = new StringBuilder();

                for (int i = 0; i < buf.Length; ++i)
                {
                    sb.Append(buf[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
