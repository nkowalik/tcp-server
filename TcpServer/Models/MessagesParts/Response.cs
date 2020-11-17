using Newtonsoft.Json;

namespace TcpServer.Models.MessagesParts
{
    public class Response
    {
        [JsonProperty("DEVTYPE")]
        public int DevType { get; set; }

        [JsonProperty("ERRORCODE")]
        public int ErrorCode { get; set; }

        [JsonProperty("ERRORCAUSE")]
        public string ErrorCause { get; set; }

        [JsonProperty("PRO")]
        public string Pro { get; set; }

        [JsonProperty("MASKCMD")]
        public int MaskCmd { get; set; }

        [JsonProperty("VCODE")]
        public string VCode { get; set; }

        [JsonProperty("S0")]
        public string S0 { get; set; }
    }
}
