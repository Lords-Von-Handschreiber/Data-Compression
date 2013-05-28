using DataCompression.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompression
{
    class Program
    {
        private static Compression _hc = new HuffmanCompression();
        private static Compression _lzw = new LZWCompression();

        static void Main(string[] args)
        {
            _hc.Progress += (i) =>
            {
                ConsoleHelpers.RenderConsoleProgress(i, '\u2590', Console.ForegroundColor, string.Format("Huffman Compression {0}% done", i));
            };
            _lzw.Progress += (i) =>
            {
                ConsoleHelpers.RenderConsoleProgress(i, '\u2590', Console.ForegroundColor, string.Format("LZW Compression {0}% done", i));
            };
            byte[] textBytes = new byte[0];
            try
            {
                using (FileStream fs = File.Open(args[0], FileMode.Open))
                using (BinaryReader sr = new BinaryReader(fs))
                {
                    textBytes = sr.ReadBytes((int)fs.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                Console.Read();
            }
            try
            {
                var b = _hc.Compress(_lzw.Compress(textBytes));
                using (FileStream fs = File.Open(args[0] + ".comp", FileMode.Create))
                {
                    fs.Write(b, 0, b.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e);
                Console.Read();
            }
        }
    }
}
