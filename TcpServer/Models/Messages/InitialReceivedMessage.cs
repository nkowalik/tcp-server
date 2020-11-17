using Newtonsoft.Json;
using TcpServer.Models.MessagesParts;

namespace TcpServer.Models.Messages
{
    public class InitialReceivedMessage
    {
        [JsonProperty("MODULE")]
        public string Module { get; set; }
        [JsonProperty("OPERATION")]
        public string Operation { get; set; }
        [JsonProperty("PARAMETER")]
        public Parameter Parameter { get; set; }
        [JsonProperty("SESSION")]
        public string Session { get; set; }
    }
}
