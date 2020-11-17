using Newtonsoft.Json;

namespace TcpServer.Models.MessagesParts
{
    public class Parameter
    {
        [JsonProperty("DEVTYPE")]
        public int DevType { get; set; }
        
        [JsonProperty("PRO")]
        public string Pro { get; set; }
    }
}
