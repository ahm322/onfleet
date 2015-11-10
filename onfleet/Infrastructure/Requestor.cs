using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace onfleet
{
    internal static class Requestor
    {
        public static string GetString(string url, ofRequestOptions requestOptions)
        {
            var wr = GetWebRequest(url, "GET", requestOptions);

            return ExecuteWebRequest(wr);
        }

        public static string PostString(string url, ofRequestOptions requestOptions)
        {
            var wr = GetWebRequest(url, "POST", requestOptions);

            return ExecuteWebRequest(wr);
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
                        oferror = Mapper<ofError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()));
                    else
                        oferror = Mapper<ofError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()), "error");

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
