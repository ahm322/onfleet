using Newtonsoft.Json;
using System;

namespace onfleet
{
    public class ofAutoAssign
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("team")]
        public string Team { set; get; }
    }
}
