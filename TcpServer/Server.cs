using System;
using System.Net;
using System.Net.Sockets;
using TcpServer.Connections;
using TcpServer.Models;

namespace TcpServer
{
    public class Server
    {
        private readonly TcpListener _tcpListener;

        public Server(int port)
        {
            _tcpListener = new TcpListener(IPAddress.Any, port);
        }

        public void Run()
        {
            _tcpListener.Start();

            Console.WriteLine("Waiting for a connection...\n");

            while (true)
            {
                HandleConnection();
            }
        }

        private async void HandleConnection()
        {
            try
            { 
                var tcpClient = await _tcpListener.AcceptTcpClientAsync();

                var dataInfo = new ReceivedDataInfo(string.Empty, DataType.InitialMessage); 
                while (dataInfo.DataType != DataType.Unknown)
                {
                    if (tcpClient.Connected)
                    {
                        var stream = tcpClient.GetStream();
                        dataInfo = Receiver.ReceiveData(tcpClient, stream);

                        Sender.SendResponse(dataInfo, stream);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
