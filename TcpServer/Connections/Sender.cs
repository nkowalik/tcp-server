using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using TcpServer.Models;

namespace TcpServer.Connections
{
    public class Sender
    {
        public static void SendResponse(ReceivedDataInfo dataInfo, Stream stream)
        {
            switch (dataInfo.DataType)
            {
                case DataType.KeepAlive:
                {
                    try
                    {
                        var outBuffer = KeepAliver.GetKeepAliveFrameOutBuffer(dataInfo);
                        stream.Write(outBuffer, 0, outBuffer.Length);

                        Console.WriteLine($"Sent keep-alive frame: {dataInfo.Content}\n");
                    }
                    catch (JsonSerializationException e)
                    {
                        Console.WriteLine($"An exception occurred while serializing KeepAlive JSON: {e}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                    break;
                }
                case DataType.InitialMessage:
                    try
                    {
                        var response = ConnectionEstablisher.CreateResponseForFirstMessage(dataInfo);
                        var outBuffer = Encoding.ASCII.GetBytes(response);
                        stream.Write(outBuffer, 0, outBuffer.Length);

                        Console.WriteLine($"Sent response: {response}\n");
                    }
                    catch (JsonSerializationException e)
                    {
                        Console.WriteLine($"An exception occurred while serializing FirstMessage JSON: {e}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;
            }
        }
    }
}
