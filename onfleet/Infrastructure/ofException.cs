using System;
using System.Net;

namespace onfleet
{
    [Serializable]
    public class ofException : ApplicationException
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public ofError ofError { get; set; }

        public ofException()
        {
        }

        public ofException(HttpStatusCode httpStatusCode, ofError oferror, string message)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
            ofError = oferror;
        }
    }
}
