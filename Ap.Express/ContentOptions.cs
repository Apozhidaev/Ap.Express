using System.Collections.Generic;

namespace Ap.Express
{
    public class ContentOptions
    {
        public static ContentOptions Web(string root)
        {
            return new ContentOptions
            {
                Root = root,
                DefaultUrl = "index.html",
                DefaultCulture = "en",
                MediaTypes = new Dictionary<string, string>
                {
                    {".html", "text/html"},
                    {".js", "application/javascript"},
                    {".css", "text/css"},
                    {".ico", "image/vnd.microsoft.icon"},
                    {".png", "image/png"},
                    {".jpg", "image/jpeg"},
                    {".eot", "application/vnd.ms-fontobject"},
                    {".svg", "image/svg+xml"},
                    {".ttf", "application/font-ttf"},
                    {".woff", "application/font-woff"},
                    {".woff2", "application/font-woff"},
                    {".appcache", "text/cache-manifest"}
                }
            };
        }

        public static ContentOptions Media(string root)
        {
            return new ContentOptions
            {
                Root = root,
                DefaultMediaType = "application/octet-stream",
                MediaTypes = new Dictionary<string, string>
                {
                    {".ico", "image/vnd.microsoft.icon"},
                    {".png", "image/png"},
                    {".jpg", "image/jpeg"},
                    {".svg", "image/svg+xml"},
                    {".txt", "text/plain"},
                    {".gif", "image/gif"},
                    {".pdf", "application/pdf"},
                    {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                    {".mp3", "audio/mpeg"}
                }
            };
        }

        public string GetMediaType(string extension)
        {
            if (MediaTypes != null && MediaTypes.ContainsKey(extension))
            {
                return MediaTypes[extension];
            }
            return DefaultMediaType;
        }


        public Dictionary<string, string> MediaTypes { get; set; }

        public string DefaultMediaType { get; set; }

        public string DefaultUrl { get; set; }

        public string Root { get; set; }

        public string DefaultCulture { get; set; }
    }
}