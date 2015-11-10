using Newtonsoft.Json;
using System;


namespace onfleet
{
    public class ofError
    {
        [JsonProperty("code")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        [JsonConverter(typeof(ofErrorMessage))]
        public ofErrorMessage Message { get; set; }

    }
}
