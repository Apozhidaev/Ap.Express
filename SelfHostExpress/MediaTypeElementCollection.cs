using System.Configuration;

namespace SelfHostExpress
{
    [ConfigurationCollection(typeof(MediaTypeElement), AddItemName = "mediaType",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class MediaTypeElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MediaTypeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MediaTypeElement)element).Extension;
        }
    }
}