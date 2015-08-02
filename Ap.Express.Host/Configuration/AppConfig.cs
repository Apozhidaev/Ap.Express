using System;
using System.Configuration;

namespace Ap.Express.Host.Configuration
{
    public static class AppConfig
    {
        private static readonly string[] _urls;
        private static readonly NetworkSection _network;

        static AppConfig()
        {
            _network = (NetworkSection)ConfigurationManager.GetSection("network");
            _urls = _network.Url.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string Description
        {
            get { return _network.Description; }
        }

        public static string DisplayName
        {
            get { return _network.DisplayName; }
        }

        public static string ServiceName
        {
            get { return _network.ServiceName; }
        }

        public static string Root
        {
            get { return _network.Root; }
        }

        public static string[] Urls
        {
            get { return _urls; }
        }
    }
}