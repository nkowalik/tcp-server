using System;
using System.Collections;
using System.IO;
using TcpServer.Extensions;
using TcpServer.Models;

namespace TcpServer.Connections
{
    public class HeaderReader
    {
        public const int HeaderBytesCount = 12;

        public static void ReadMessageHeader(Stream stream)
        {
            var headerData = new byte[HeaderBytesCount];
            stream.Read(headerData, 0, HeaderBytesCount);
            var bits = new BitArray(headerData);
            var header = new Header
            {
                VersionNumber = bits.CopySlice(0, 2).ToInt(),
                PaddingField = bits.CopySlice(2, 1).ToInt(),
                ImportantEvents = bits.CopySlice(3, 1).ToInt(),
                ContributorsCount = bits.CopySlice(4, 4).ToInt(),
                PayloadType = bits.CopySlice(8, 8).ToInt(),
                SynchronizationSourceIdentifier = bits.CopySlice(16, 16).ToInt(),
                PayloadDataLength = bits.CopySlice(32, 32).ToInt()
            };

            Console.WriteLine(
                $"Header\nversion: {header.VersionNumber}, number of contributors: {header.ContributorsCount}, " +
                $"payload data type: {header.PayloadType}, payload data length: {header.PayloadDataLength}, " +
                $"Synchronization Source Identifier: {header.SynchronizationSourceIdentifier}\n");
        }
    }
}
