using System;

namespace TcpServer
{
    internal class Program
    {
        private static void Main()
        {
            const int port = 9005;
            var server = new Server(port);
            server.Run();

            Console.ReadLine();
        }
    }
}