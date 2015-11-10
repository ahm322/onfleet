using Newtonsoft.Json;
using System;


namespace onfleet
{
    public abstract class ofObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
