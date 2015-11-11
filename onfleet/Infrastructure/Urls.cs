using System;

namespace onfleet
{
    internal static class Urls
    {
        public static string Organization
        {
            get { return BaseUrl + "/organization"; }
        }

        public static string Workers
        {
            get { return BaseUrl + "/workers"; }
        }

        public static string Destinations
        {
            get { return BaseUrl + "/destinations"; }
        }

        public static string Recipients
        {
            get { return BaseUrl + "/recipients"; }
        }

        public static string Tasks
        {
            get { return BaseUrl + "/tasks"; }
        }

        public static string Teams
        {
            get { return BaseUrl + "/teams"; }
        }

        private static string BaseUrl
        {
            get { return "https://onfleet.com/api/v2"; }
        }

    }
}
