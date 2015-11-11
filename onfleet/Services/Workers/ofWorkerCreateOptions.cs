using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace onfleet
{
    public class ofWorkerCreateOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("teams")]
        public List<string> Teams { get; set; }

        [JsonProperty("vehicle")]
        public ofVehicleCreateOptions Vehicle { get; set; }
    }
}
