using Newtonsoft.Json;
using System;


namespace onfleet
{
    public class ofAddress : ofObject
    {
        [JsonProperty("apartment")]
        public string Apartment { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("unparsed")]
        public string Unparsed { get; set; }
    }
}
