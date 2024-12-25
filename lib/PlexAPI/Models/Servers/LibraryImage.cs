using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    public class LibraryImage
    {
        [XmlAttribute("alt")]
        public string Alt { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("url")]
        public string Url { get; set; }
    }
}
