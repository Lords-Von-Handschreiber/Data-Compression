using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompression.Core
{
    public interface ICompression
    {
        byte[] Compress(byte[] input);
        byte[] Decompress(byte[] input);
        void Compress(Stream input, Stream output);
        void Decompress(Stream input, Stream output);
        void Compress(BinaryReader reader, BinaryWriter writer);
        void Decompress(BinaryReader reader, BinaryWriter writer);
    }
}
