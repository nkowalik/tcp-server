using Newtonsoft.Json;

namespace TcpServer.Models.Messages
{
    public class KeepAliveMessage
    {
        [JsonProperty("MODULE")]
        public string Module { get; set; }
        
        [JsonProperty("OPERATION")]
        public string Operation { get; set; }

        [JsonProperty("SESSION")]
        public string Session { get; set; }
    }
}
