using System;
using System.Configuration;

namespace Express.Tests.Configuration
{
    public static class AppSettings
    {
        private static readonly string[] _urls;
        private static readonly GlobalSection _global;

        static AppSettings()
        {
            _global = (GlobalSection)ConfigurationManager.GetSection("global");
            _urls = _global.Url.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string Description
        {
            get { return _global.Description; }
        }

        public static string DisplayName
        {
            get { return _global.DisplayName; }
        }

        public static string ServiceName
        {
            get { return _global.ServiceName; }
        }

        public static string Root
        {
            get { return _global.Root; }
        }

        public static string[] Urls
        {
            get { return _urls; }
        }
    }
}