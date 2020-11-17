using Newtonsoft.Json;
using TcpServer.Models;
using TcpServer.Models.Messages;
using TcpServer.Models.MessagesParts;

namespace TcpServer.Connections
{
    public class ConnectionEstablisher
    {
        public static string CreateResponseForFirstMessage(ReceivedDataInfo dataInfo)
        {
            var receivedMessage = JsonConvert.DeserializeObject<InitialReceivedMessage>(dataInfo.Content);

            if (receivedMessage == null) return null;

            var responseMessage = new ResponseMessage
            {
                Module = receivedMessage.Module,
                Operation = receivedMessage.Operation,
                Response = new Response
                {
                    DevType = receivedMessage.Parameter.DevType,
                    ErrorCode = 0,
                    ErrorCause = string.Empty,
                    Pro = receivedMessage.Parameter.Pro,
                    MaskCmd = 5,
                    VCode = string.Empty,
                    S0 = string.Empty
                },
                Session = receivedMessage.Session
            };
            
            return JsonConvert.SerializeObject(responseMessage);
        }
    }
}
