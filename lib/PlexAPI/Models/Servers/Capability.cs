using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    public class Capability
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}
