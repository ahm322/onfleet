using Newtonsoft.Json;
using System;

namespace onfleet
{
    public class ofWorkerCreateOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("teams")]
        public string[] Teams { get; set; }

        [JsonProperty("vehicle")]
        public ofVehicle Vehicle { get; set; }
    }
}
