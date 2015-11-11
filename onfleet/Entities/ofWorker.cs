using System;
using Newtonsoft.Json;
using onfleet.Infrastructure;
using System.Collections.Generic;

namespace onfleet
{
    public class ofWorker : ofObject
    {
        [JsonProperty("timeCreated")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("timeLastModified")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime LastModified { get; set; }

        [JsonProperty("organization")]
        public string OrganizationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("vehicle")]
        public ofVehicle Vehicle { get; set; }

        [JsonProperty("activeTask")]
        public string ActiveTaskId { get; set; }

        [JsonProperty("tasks")]
        public List<string> Tasks { get; set; }

        [JsonProperty("onDuty")]
        public bool OnDuty { get; set; }

        [JsonProperty("location")]
        public double[] Location { get; set; }

        [JsonProperty("timeLastSeen")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime? TimeLastSeen { get; set; }

        [JsonProperty("delayTime")]
        public TimeSpan? DelayTime { get; set; }

        [JsonProperty("teams")]
        public string[] Teams { get; set; }

        [JsonProperty("metadata")]
        public List<ofMetaData> Metadata { get; set; }
    }
}
