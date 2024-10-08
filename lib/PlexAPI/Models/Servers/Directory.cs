using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    public class Directory
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}
