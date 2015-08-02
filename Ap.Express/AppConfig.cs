using System.Collections.Generic;
using System.Configuration;

namespace Ap.Express
{
    internal static class AppConfig
    {
        private static readonly string _defaultMediaType;
        private static readonly Dictionary<string, string> _mediaTypes = new Dictionary<string, string>();

        static AppConfig()
        {
            var content = (ContentSection)ConfigurationManager.GetSection("apExpress");
            _defaultMediaType = content.DefaultMediaType;
            foreach (MediaTypeElement mediaType in content.MediaTypes)
            {
                _mediaTypes.Add(mediaType.Extension, mediaType.Value);
            }
        }

        public static string GetMediaType(string extension)
        {
            if (_mediaTypes.ContainsKey(extension))
            {
                return _mediaTypes[extension];
            }
            return _defaultMediaType;
        }

        public static string Root { get; set; }
    }
}