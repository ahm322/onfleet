using Newtonsoft.Json;
using System;

namespace onfleet
{
    public class ofRecipientsCreateOptions
    {
        public ofRecipientsCreateOptions()
        {
            SkipSMSNotifications = true;
            SkipPhoneNumberValidation = true;
        }

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
