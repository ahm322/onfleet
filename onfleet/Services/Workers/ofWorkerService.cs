using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace onfleet
{
    public class ofWorkerService : ofService
    {
        public ofWorkerService(string apiKey = null) : base(apiKey) { }
               
        public virtual ofWorker Create(ofWorkerCreateOptions createOptions, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            string serilizedObj = JsonConvert.SerializeObject(createOptions, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }).ToString();
            var PostData = new StringContent(serilizedObj, Encoding.UTF8, "application/json");
            var worker = Requestor.Post<ofWorker>(Urls.Workers, requestOptions, PostData);
            return worker;
        }

        public virtual ofWorker Get(string workerId, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var worker = Requestor.Get<ofWorker>(string.Format("{0}/{1}", Urls.Workers, workerId), requestOptions);
            return worker;
        }

        public virtual ofWorker Update(string workerId, ofWorkerUpdateOptions updateOptions, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            string serilizedObj = JsonConvert.SerializeObject(updateOptions, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }).ToString();
            var PostData = new StringContent(serilizedObj, Encoding.UTF8, "application/json");
            var worker = Requestor.Put<ofWorker>(string.Format("{0}/{1}", Urls.Workers, workerId), requestOptions, PostData);
            return worker;
        }

        public virtual void Delete(string workerId, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}", Urls.Workers, workerId);

            Requestor.Delete(url, requestOptions);
        }

        public virtual IEnumerable<ofWorker> List(ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var workers = Requestor.Get<List<ofWorker>>(Urls.Workers, requestOptions);
            return workers;
        }
    }
}
