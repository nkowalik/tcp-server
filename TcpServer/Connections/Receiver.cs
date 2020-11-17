using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using TcpServer.Models;

namespace TcpServer.Connections
{
    public class Receiver
    {
        public static ReceivedDataInfo ReceiveData(TcpClient tcpClient, Stream stream)
        {
            HeaderReader.ReadMessageHeader(stream);

            var buffer = new byte[tcpClient.ReceiveBufferSize];
            var bytesRead = stream.Read(buffer, 0, tcpClient.ReceiveBufferSize - HeaderReader.HeaderBytesCount);
            var content = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            var dataType = GetDataType(content);

            Console.WriteLine($"Received {Enum.GetName(typeof(DataType), dataType)}: {content}\n");

            if (dataType == DataType.GpsData)
            {
                var gpsMessage = GpsDataReader.ReadData(buffer, content);
                Console.WriteLine(gpsMessage.ToString());
            }

            return new ReceivedDataInfo(content, dataType);
        }

        private static DataType GetDataType(string data)
        {
            const string initialMessagePart = "parameter";
            const char jsonStartChar = '{';

            if (data.Equals(string.Empty))
            {
                return DataType.Unknown;
            }

            if (!data.Contains(jsonStartChar))
            {
                return DataType.GpsData;
            }

            return data.ToLower().Contains(initialMessagePart)
                ? DataType.InitialMessage
                : DataType.KeepAlive;
        }
    }
}
