using System;
using System.Collections;
using System.Text;

namespace TcpServer.Extensions
{
    public static class BitArrayExtensions
    {
        public static int ToInt(this BitArray bits)
        {
            return Convert.ToInt32(ToBitString(bits), 2);
        }

        public static string ToBitString(this BitArray bits)
        {
            const char falseChar = '0';
            const char trueChar = '1';
            var sb = new StringBuilder();

            for (var i = 0; i < bits.Count; i++)
            {
                var c = bits[i] ? trueChar : falseChar;
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static BitArray CopySlice(this BitArray source, int offset, int length)
        {
            var bits = new BitArray(length);
            for (var i = 0; i < length; i++)
            {
                bits[i] = source[offset + i];
            }
            return bits;
        }
    }
}
