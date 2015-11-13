using Newtonsoft.Json;
using System;


namespace onfleet
{
    public class ofError
    {
        [JsonProperty("code")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        public ofErrorMessage Message { get; set; }

    }
}
