using Newtonsoft.Json;
using onfleet.Infrastructure;
using System;
using System.Collections.Generic;


namespace onfleet
{
    public class ofTask : ofObject
    {
        [JsonProperty("timeCreated")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("timeLastModified")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime LastModified { get; set; }

        [JsonProperty("organization")]
        public string OrganizationId { get; set; }

        [JsonProperty("shortId")]
        public string ShortId { get; set; }

        [JsonProperty("worker")]
        public string WorkerId { set; get; }

        [JsonProperty("merchant")]
        public string MerchantId { get; set; }

        [JsonProperty("executor")]
        public string ExecutorId { get; set; }

        [JsonProperty("creator")]
        public string CreatorId { get; set; }

        [JsonProperty("destination")]
        public ofDestination Destination { get; set; }

        [JsonProperty("dependencies")]
        public List<string> Dependencies { get; set; }

        [JsonProperty("recipients")]
        public List<string> Recipients { get; set; }

        [JsonProperty("state")]
        public TaskState State { get; set; }

        [JsonProperty("completeAfter")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime? CompleteAfter { get; set; }

        [JsonProperty("completeBefore")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime? CompleteBefore { get; set; }

        [JsonProperty("pickupTask")]
        public bool PickupTask { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
