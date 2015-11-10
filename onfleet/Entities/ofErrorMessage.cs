using Newtonsoft.Json;
using System;

namespace onfleet
{
    public class ofErrorMessage
    {
        [JsonProperty("error")]
        public int ErrorNumber { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("docs")]
        public string Docs { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }

        [JsonProperty("cause")]
        public string Cause { get; set; }

    }
}
