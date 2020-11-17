using System.Text;
using Newtonsoft.Json;
using TcpServer.Models;
using TcpServer.Models.Messages;

namespace TcpServer.Connections
{
    public class KeepAliver
    {
        public static byte[] GetKeepAliveFrameOutBuffer(ReceivedDataInfo dataInfo)
        {
            JsonConvert.DeserializeObject<KeepAliveMessage>(dataInfo.Content);
            return Encoding.ASCII.GetBytes(dataInfo.Content);
        }
    }
}
