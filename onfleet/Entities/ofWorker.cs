using System;
using Newtonsoft.Json;
using onfleet.Infrastructure;

namespace onfleet
{
    class ofWorker
    {
        [JsonProperty("id")]
        public string id {get;}

        [JsonProperty("timeCreated")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime Created { get; }

        [JsonProperty("timeLastModified")]
        [JsonConverter(typeof(ofDateTimeConverter))]
        public DateTime LastModified { get; }

        [JsonProperty("organization")]


  "organization": "Oq5F4bYJIFspkVj*u*p*Tyim",
  "name": "Marco Emery",
  "phone": "+14153420112",
  "vehicle": {
    "id": "pHKMR~swoyxCdY1HhsUUswzU",
    "type": "CAR",
    "description": "Tesla Model 3",
    "licensePlate": "CA 2LOV733",
    "color": "purple"
  },
  "activeTask": null,
  "tasks": [
    "MG*Q*LjLBwl3rhBaN997ZADK",
    "mDL9cjR5n4h2UxRTWJelujjL",
    "dvnOWcRPwgujiFKuUZCQqVJx"
  ],
  "onDuty": true,
  "location": [
    -122.4014002,
    37.776398
  ],
  "timeLastSeen": 1435876916385,
  "delayTime": 1362179,
  "teams": [
    "40w3cDGO*xfBT0AzL0G*FEBw"
  ],
  "metadata": [],
  "analytics": {
    "events": [
      {
        "action": "onduty",
        "time": 1435876836060
      },
      {
        "action": "offduty",
        "time": 1435876865890
      },
      {
        "action": "onduty",
        "time": 1435876875738
      },
      {
        "action": "offduty",
        "time": 1435876910948
      }
    ],
    "distances": {
      "enroute": 5274.28,
      "idle": 8130.84
    },
    "times": {
      "enroute": 29700.73,
      "idle": 49688.54
    }
  }
}
    }
}
