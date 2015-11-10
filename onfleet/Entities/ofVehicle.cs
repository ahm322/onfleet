using Newtonsoft.Json;
using System;


namespace onfleet
{
    public class ofVehicle : ofObject
    {
        [JsonProperty("type")]
        public string VehicleType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("licensePlate")]
        public string LicensePlate { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
