
namespace ITServices.Framework
{
    using System.Collections.Specialized;
    using System.Configuration;
    public static class ITServicesConfig
    {
        public static string BaseUri;
        public static void Configure()
        {
           SetBaseUri();
        }
        private static void SetBaseUri()
        {
            string baseUri = string.Empty;
            var collection = new NameValueCollection();
            collection = (NameValueCollection)ConfigurationManager.GetSection("ITServicesSettings");

            switch (collection["RunMode"].ToUpper())
            {
                case "DEVELOPER":
                    BaseUri = "http://itservicesdev.careerbuilder.com/";
                    break;

                case "TEST":
                    BaseUri = "https://itservicestest.cb.com/";
                    break;

                case "PRODUCTION":
                    BaseUri = "https://itservices.cb.com/";
                    break;
            }
           

        }
    }
}