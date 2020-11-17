﻿using Newtonsoft.Json;
using TcpServer.Models.MessagesParts;

namespace TcpServer.Models.Messages
{
    public class ResponseMessage
    {
        [JsonProperty("MODULE")]
        public string Module { get; set; }

        [JsonProperty("OPERATION")]
        public string Operation { get; set; }

        [JsonProperty("SESSION")]
        public string Session { get; set; }

        [JsonProperty("RESPONSE")]
        public Response Response { get; set; }
    }
}
