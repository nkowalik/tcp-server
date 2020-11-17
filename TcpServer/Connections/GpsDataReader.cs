using System;
using System.Collections;
using TcpServer.Extensions;
using TcpServer.Models.Messages;

namespace TcpServer.Connections
{
    public class GpsDataReader
    {
        public static GpsMessage ReadData(byte[] data, string content)
        {
            const int bitesInByte = 8;
            const int charSize = sizeof(char) * bitesInByte;
            const int intSize = sizeof(int) * bitesInByte;
            const int arraySize = 16;
            var offset = 0;
            var bits = new BitArray(data);

            var viled = GetNextIntFromBitArray(bits, charSize, ref offset);
            var uExpand = GetNextIntFromBitArray(bits, charSize, ref offset);
            var uReal = GetNextIntFromBitArray(bits, charSize, ref offset);
            var reserver = GetNextIntFromBitArray(bits, charSize, ref offset);

            return new GpsMessage
            {
                Viled = Convert.ToChar(viled),
                UExpand = Convert.ToChar(uExpand),
                UReal = Convert.ToChar(uReal),
                Reserver = new[] { Convert.ToChar(reserver) },
                Longitude = bits[offset] ? "west" : "east",
                ULongitude = bits.CopySlice(offset + 1, intSize - 1).ToInt(),
                Latitude = bits[offset + charSize * 2] ? "south" : "north",
                ULatitude = bits.CopySlice(offset + intSize + 1, intSize - 1).ToInt(),
                UDirect = bits.CopySlice(offset + intSize * 2, intSize).ToInt(),
                UHigh = bits.CopySlice(offset + intSize * 3, intSize).ToInt(),
                UTime = content.Substring(content.Length-arraySize)
            };
        }

        private static int GetNextIntFromBitArray(BitArray bits, int charSize, ref int offset)
        {
            var result = bits.CopySlice(offset, charSize).ToInt();
            offset += charSize;
            return result;
        }
    }
}
