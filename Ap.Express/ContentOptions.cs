using System.Collections.Generic;

namespace Ap.Express
{
    public class ContentOptions
    {
        public ContentOptions(string root)
        {
            Root = root;
            MediaTypes = new Dictionary<string, string>();
            CultureResources = new HashSet<string>();
        }

        public string Root { get; set; }

        public string DefaultUrl { get; set; }

        public string DefaultMediaType { get; set; }

        public string DefaultCulture { get; set; }

        public Dictionary<string, string> MediaTypes { get; private set; }

        public HashSet<string> CultureResources { get; private set; }

        public string GetMediaType(string extension)
        {
            if (MediaTypes.ContainsKey(extension))
            {
                return MediaTypes[extension];
            }
            return DefaultMediaType;
        }
    }
}