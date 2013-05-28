using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompression
{
    public static class StringHelpers
    {
        private static Encoding enc = new ASCIIEncoding();

        public static byte[] GetBytes(this string s)
        {
            return enc.GetBytes(s);
        }

        public static string GetString(this byte[] b)
        {
            return enc.GetString(b);
        }
    }
}
