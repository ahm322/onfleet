﻿using Newtonsoft.Json;
using onfleet.Infrastructure;
using System;
using System.Collections.Generic;

namespace onfleet
{
    public class ofOrganization : ofObject
    {
        [JsonProperty("timeCreated")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("timeLastModified")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime LastModified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("delegatees")]
        public string[] Delegatees { get; set; }

    }
}
