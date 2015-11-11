using Newtonsoft.Json;
using System;

namespace onfleet
{
    public class ofDestinationCreateOptions
    {
        [JsonProperty("location")]
        public double[] Location { get; set; }

        [JsonProperty("address")]
        public ofAddress Address { set; get; }
    }
}
