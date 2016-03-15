using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace onfleet
{
    public class ofTaskService : ofService
    {
        public ofTaskService(string apiKey = null) : base(apiKey) { }

        public virtual IEnumerable<ofTask> List(ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);
            var tasks = Requestor.Get<List<ofTask>>(Urls.Tasks, requestOptions);

            return tasks;
        }

        public virtual ofTask Create(ofTaskCreateOptions createOptions, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var serilizedObj = JsonConvert.SerializeObject(createOptions,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            var postData = new StringContent(serilizedObj, Encoding.UTF8, "application/json");
            var task = Requestor.Post<ofTask>(Urls.Tasks, requestOptions, postData);
            return task;
        }

        public virtual ofTask Get(string taskId, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var task = Requestor.Get<ofTask>(string.Format("{0}/{1}", Urls.Tasks, taskId), requestOptions);
            return task;
        }

        public ofTask Update(string taskId, ofTaskCreateOptions options, ofRequestOptions requestOptions)
        {
            requestOptions = SetupRequestOptions(requestOptions);
            var serilizedObj = JsonConvert.SerializeObject(options, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            var postData = new StringContent(serilizedObj, Encoding.UTF8, "application/json");

            return Requestor.Put<ofTask>(string.Format("{0}/{1}", Urls.Tasks, taskId), requestOptions, postData);
        }
    }
}
