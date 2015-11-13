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
            var responseString = responseMessage.Content.ReadAsStringAsync().Result;
            
            if (responseMessage.IsSuccessStatusCode)
            {
                T obj = JsonConvert.DeserializeObject<T>(responseString);
                return obj;
            }
            else
            {
                ofError err = JsonConvert.DeserializeObject<ofError>(responseString);
                throw new ofException(responseMessage.StatusCode, err);
            }
        }

        public static T Post<T>(string url, ofRequestOptions requestOptions, StringContent content = null)
        {
            var client = GetHttpClient(requestOptions);

            var responseMessage = client.PostAsync(url, content).Result;
            var responseString = responseMessage.Content.ReadAsStringAsync().Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                
                T obj = JsonConvert.DeserializeObject<T>(responseString);
                return obj;
            }
            else
            {
                ofError err = JsonConvert.DeserializeObject<ofError>(responseString);
                throw new ofException(responseMessage.StatusCode, err);
            }
        }

        public static T Put<T>(string url, ofRequestOptions requestOptions, StringContent content = null)
        {
            var client = GetHttpClient(requestOptions);

            var responseMessage = client.PutAsync(url, content).Result;
            var responseString = responseMessage.Content.ReadAsStringAsync().Result;
                
            if (responseMessage.IsSuccessStatusCode)
            {
                T obj = JsonConvert.DeserializeObject<T>(responseString);
                return obj;
            }
            else
            {
                ofError err = JsonConvert.DeserializeObject<ofError>(responseString);
                throw new ofException(responseMessage.StatusCode, err);
            }
        }

        public static void Delete(string url, ofRequestOptions requestOptions)
        {
            var client = GetHttpClient(requestOptions);

            var responseMessage = client.DeleteAsync(url).Result;
            var responseString = responseMessage.Content.ReadAsStringAsync().Result;
            if (!responseMessage.IsSuccessStatusCode)
            {
                ofError err = JsonConvert.DeserializeObject<ofError>(responseString);
                throw new ofException(responseMessage.StatusCode, err);
            }
            
        }

        internal static HttpClient GetHttpClient(ofRequestOptions requestOptions)
        {
            requestOptions.ApiKey = requestOptions.ApiKey ?? ofConfiguration.GetApiKey();
            HttpClient client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes(requestOptions.ApiKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
