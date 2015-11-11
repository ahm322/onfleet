using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace onfleet
{
    public class ofMetaData
    {
        public ofMetaData()
        { 
            Name = "";
            Type = MetaDataTypes.String;
            SubType = MetaDataTypes.String;
            Visibility = new List<string> { "api"};
            Value = "";
        }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("subtype")]
        public string SubType { get; set; }

        [JsonProperty("visibility")]
        public List<string> Visibility { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

    }
}
