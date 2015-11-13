using System;
using System.Net;

namespace onfleet
{
    [Serializable]
    public class ofException : ApplicationException
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public ofError Error { get; set; }

        public ofException()
        {
        }

        public ofException(HttpStatusCode httpStatusCode, ofError error, string message)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
            Error = error;
        }

        public ofException(HttpStatusCode httpStatusCode, ofError oferror)
            : base(oferror.Message.Message)
        {
            HttpStatusCode = httpStatusCode;
            Error = oferror;
        }
    }
}
