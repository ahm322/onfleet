using Newtonsoft.Json;
using onfleet.Infrastructure;
using System;

namespace onfleet
{
    public class ofDestination : ofObject
    {
        [JsonProperty("timeCreated")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("timeLastModified")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime LastModified { get; set; }

        [JsonProperty("location")]
        public double[] Location { get; set; }

        [JsonProperty("address")]
        [JsonConverter(typeof(ofAddress))]
        public ofAddress Address { set; get; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("tasks")]
        public string[] Tasks { get; set; }
    }
}
