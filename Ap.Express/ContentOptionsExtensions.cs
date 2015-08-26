namespace Ap.Express
{
    public static class ContentOptionsExtensions
    {
        public static ContentOptions UseWeb(this ContentOptions options)
        {
            options.DefaultUrl = "index.html";
            options.SetMediaType(".html", "text/html");
            options.SetMediaType(".js", "application/javascript");
            options.SetMediaType(".css", "text/css");
            options.SetMediaType(".ico", "image/vnd.microsoft.icon");
            options.SetMediaType(".png", "image/png");
            options.SetMediaType(".jpg", "image/jpeg");
            options.SetMediaType(".eot", "application/vnd.ms-fontobject");
            options.SetMediaType(".svg", "image/svg+xml");
            options.SetMediaType(".ttf", "application/font-ttf");
            options.SetMediaType(".woff", "application/font-woff");
            options.SetMediaType(".woff2", "application/font-woff");
            options.SetMediaType(".appcache", "text/cache-manifest");
            return options;
        }

        public static ContentOptions UseMedia(this ContentOptions options)
        {
            options.DefaultMediaType = "application/octet-stream";
            options.SetMediaType(".ico", "image/vnd.microsoft.icon");
            options.SetMediaType(".png", "image/png");
            options.SetMediaType(".jpg", "image/jpeg");
            options.SetMediaType(".svg", "image/svg+xml");
            options.SetMediaType(".txt", "text/plain");
            options.SetMediaType(".gif", "image/gif");
            options.SetMediaType(".pdf", "application/pdf");
            options.SetMediaType(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            options.SetMediaType(".mp3", "audio/mpeg");
            return options;
        }

        public static ContentOptions UseCulture(this ContentOptions options, params string[] resources)
        {
            options.DefaultCulture = "en";
            foreach (var resource in resources)
            {
                options.CultureResources.Add(resource);
            }
            return options;
        }

        public static void SetMediaType(this ContentOptions options, string extension, string value)
        {
            options.MediaTypes[extension] = value;
        }
    }
}