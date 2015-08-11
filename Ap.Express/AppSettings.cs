using System.Collections.Generic;
using System.Configuration;

namespace Ap.Express
{
    internal static class AppSettings
    {
        private static string _root;
        private static readonly string _defaultUrl;
        private static readonly string _defaultMediaType;
        private static readonly Dictionary<string, string> _mediaTypes = new Dictionary<string, string>();

        static AppSettings()
        {
            var content = (ContentSection)ConfigurationManager.GetSection("apExpress");
            _defaultUrl = content.DefaultUrl;
            _defaultMediaType = content.DefaultMediaType;
            foreach (MediaTypeElement mediaType in content.MediaTypes)
            {
                _mediaTypes.Add(mediaType.Extension, mediaType.Value);
            }
        }

        public static void UseStatic(string root)
        {
            _root = root;
        }

        public static string DefaultUrl
        {
            get { return _defaultUrl; }
        }

        public static string GetMediaType(string extension)
        {
            if (_mediaTypes.ContainsKey(extension))
            {
                return _mediaTypes[extension];
            }
            return _defaultMediaType;
        }

        public static string Root
        {
            get { return _root; }
        }
    }
}