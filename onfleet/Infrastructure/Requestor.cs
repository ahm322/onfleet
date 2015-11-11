using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace onfleet
{
    internal static class Requestor
    {
        public static T Get<T>(string url, ofRequestOptions requestOptions, StringContent content = null)
        {
            var client = GetHttpClient(requestOptions);

            var responseMessage = client.GetAsync(url).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseString = responseMessage.Content.ReadAsStringAsync().Result;
                T obj = JsonConvert.DeserializeObject<T>(responseString);
                return obj;
            }
            return default(T);
        }

        public static T Post<T>(string url, ofRequestOptions requestOptions, StringContent content = null)
        {
            var client = GetHttpClient(requestOptions);

            var responseMessage = client.PostAsync(url, content).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseString = responseMessage.Content.ReadAsStringAsync().Result;
                T obj = JsonConvert.DeserializeObject<T>(responseString);
                return obj;
            }
            return default(T);
        }

        public static string Delete(string url, ofRequestOptions requestOptions)
        {
            var wr = GetWebRequest(url, "DELETE", requestOptions);

            return ExecuteWebRequest(wr);
        }

        public static string PostStringBearer(string url, ofRequestOptions requestOptions)
        {
            var wr = GetWebRequest(url, "POST", requestOptions, true);

            return ExecuteWebRequest(wr);
        }

        internal static HttpClient GetHttpClient(ofRequestOptions requestOptions)
        {
            HttpClient client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes(requestOptions.ApiKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        internal static WebRequest GetWebRequest(string url, string method, ofRequestOptions requestOptions, bool useBearer = false)
        {
            requestOptions.ApiKey = requestOptions.ApiKey ?? ofConfiguration.GetApiKey();

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;

            if (!useBearer)
                request.Headers.Add("Authorization", GetAuthorizationHeaderValue(requestOptions.ApiKey));
            else
                request.Headers.Add("Authorization", GetAuthorizationHeaderValueBearer(requestOptions.ApiKey));

            request.Headers.Add("Stripe-Version", ofConfiguration.ApiVersion);
                        
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Donkeyrun";

            return request;
        }

        private static string GetAuthorizationHeaderValue(string apiKey)
        {
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", apiKey)));
            return string.Format("Basic {0}", token);
        }

        private static string GetAuthorizationHeaderValueBearer(string apiKey)
        {
            return string.Format("Bearer {0}", apiKey);
        }

        private static string ExecuteWebRequest(WebRequest webRequest)
        {
            try
            {
                using (var response = webRequest.GetResponse())
                {
                    return ReadStream(response.GetResponseStream());
                }
            }
            catch (WebException webException)
            {
                if (webException.Response != null)
                {
                    var statusCode = ((HttpWebResponse)webException.Response).StatusCode;

                    var oferror = new ofError();

                    if (webRequest.RequestUri.ToString().Contains("oauth"))
                       // oferror = Mapper<ofError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()));
                    //else
                        //oferror = Mapper<ofError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()), "error");

                    throw new ofException(statusCode, oferror, oferror.Message.Message);
                }

                throw;
            }
        }

        private static string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
