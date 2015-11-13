using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace onfleet
{
    public class ofWorkerUpdateOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teams")]
        public List<string> Teams { get; set; }

        [JsonProperty("vehicle")]
        public ofVehicle Vehicle { get; set; }

        [JsonProperty("tasks")]
        public List<string> Tasks { get; set; }
    }
}
