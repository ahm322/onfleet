using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using onfleet.Infrastructure;

namespace onfleet
{
    public class ofTaskCreateOptions
    {
        [JsonProperty("merchant")]
        public string Merchant { get; set; }

        [JsonProperty("executor")]
        public string Executor { get; set; }

        [JsonProperty("destination")]
        public string DestinationId { get; set; }

        [JsonProperty("recipients")]
        public List<string> Recipients { get; set; }

        [JsonProperty("completeAfter")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime? CompleteAfter { get; set; }

        [JsonProperty("completeBefore")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime? CompleteBefore { get; set; }

        [JsonProperty("pickupTask")]
        public bool PickupTask { get; set; }

        [JsonProperty("dependencies")]
        public List<string> Dependencies { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("autoAssign")]
        public ofAutoAssign AutoAssign { get; set; }

        [JsonProperty("metadata")]
        public List<ofMetaData> MetaData { get; set; }
    }
}
