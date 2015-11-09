using Newtonsoft.Json;
using onfleet.Infrastructure;
using System;
using System.Collections.Generic;

namespace onfleet
{
    class ofOrganization
    {
        [JsonProperty("id")]
        public string id { get; }

        [JsonProperty("timeCreated")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime Created { get; }

        [JsonProperty("timeLastModified")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime LastModified { get; }

        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("email")]
        public string Email { get; }

        [JsonProperty("timezone")]
        public string TimeZone { get; }

        [JsonProperty("country")]
        public string Country { get; }

        [JsonArray("delegatees")]
        public string[] Delegatees { get; }

    }
}
