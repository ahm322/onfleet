using Newtonsoft.Json;
using onfleet.Infrastructure;
using System;
using System.Collections.Generic;

namespace onfleet
{
    public class ofTeam :ofObject
    {
        [JsonProperty("timeCreated")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("timeLastModified")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime LastModified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("workers")]
        public List<string> Workers { get; set; }

        [JsonProperty("managers")]
        public List<string> Managers { get; set; }
    }
}
