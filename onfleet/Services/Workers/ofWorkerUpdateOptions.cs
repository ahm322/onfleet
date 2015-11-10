using Newtonsoft.Json;
using System;

namespace onfleet
{
    public class ofWorkerUpdateOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teams")]
        public string[] Teams { get; set; }

        [JsonProperty("vehicle")]
        [JsonConverter(typeof(ofVehicle))]
        public ofVehicle Vehicle { get; set; }

        [JsonProperty("taska")]
        public string[] Tasks { get; set; }
    }
}
