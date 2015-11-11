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

            string serilizedObj = JsonConvert.SerializeObject(createOptions).ToString();
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

        //public virtual ofWorker Update(string workerId, ofWorkerUpdateOptions updateOptions, ofRequestOptions requestOptions = null)
        //{
        //    requestOptions = SetupRequestOptions(requestOptions);

        //    var url = string.Format("{0}/{1}", Urls.Workers, workerId);
        //    url = this.ApplyAllParameters(updateOptions, url, false);

        //    var response = Requestor.PostString(url, requestOptions);

        //    return Mapper<ofWorker>.MapFromJson(response);
        //}

        //public virtual void Delete(string workerId, ofRequestOptions requestOptions = null)
        //{
        //    requestOptions = SetupRequestOptions(requestOptions);

        //    var url = string.Format("{0}/{1}", Urls.Workers, workerId);

        //    Requestor.Delete(url, requestOptions);
        //}

        //public virtual IEnumerable<ofWorker> List(ofRequestOptions requestOptions = null)
        //{
        //    requestOptions = SetupRequestOptions(requestOptions);

        //    var url = Urls.Workers;
        //    url = this.ApplyAllParameters(null, url, true);

        //    var response = Requestor.GetString(url, requestOptions);

        //    return Mapper<ofWorker>.MapCollectionFromJson(response);
        //}
    }
}
