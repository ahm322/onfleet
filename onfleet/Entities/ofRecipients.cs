using Newtonsoft.Json;
using onfleet.Infrastructure;
using System;


namespace onfleet
{
    public class ofRecipient : ofObject
    {
        [JsonProperty("timeCreated")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("timeLastModified")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime LastModified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("skipSMSNotifications")]
        public bool SkipSMSNotifications { get; set; }

        [JsonProperty("skipPhoneNumberValidation")]
        public bool SkipPhoneNumberValidation { get; set; }
    }
}
