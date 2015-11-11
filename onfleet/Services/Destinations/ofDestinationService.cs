using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace onfleet
{
    public class ofDestinationService : ofService
    {
        public ofDestinationService(string apiKey = null) : base(apiKey) { }

        public virtual ofDestination Create(ofDestinationCreateOptions createOptions, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            string serilizedObj = JsonConvert.SerializeObject(createOptions, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }).ToString();
            var PostData = new StringContent(serilizedObj, Encoding.UTF8, "application/json");
            var destination = Requestor.Post<ofDestination>(Urls.Destinations, requestOptions, PostData);
            return destination;
        }

        public virtual ofDestination Get(string destinationId, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var destination = Requestor.Get<ofDestination>(string.Format("{0}/{1}", Urls.Destinations, destinationId), requestOptions);
            return destination;
        }
    }
}
