using System.Configuration;

namespace Ap.Express.Host.Configuration
{
    public class GlobalSection : ConfigurationSection
    {
        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }
        }


        [ConfigurationProperty("serviceName", IsRequired = true)]
        public string ServiceName
        {
            get
            {
                return (string)this["serviceName"];
            }
        }

        [ConfigurationProperty("displayName", IsRequired = true)]
        public string DisplayName
        {
            get
            {
                return (string)this["displayName"];
            }
        }

        [ConfigurationProperty("description", IsRequired = true)]
        public string Description
        {
            get
            {
                return (string)this["description"];
            }
        }

        [ConfigurationProperty("root", IsRequired = true)]
        public string Root
        {
            get
            {
                return (string)this["root"];
            }
        }
    }
}