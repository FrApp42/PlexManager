using System.Xml.Serialization;

namespace PlexAPI.Models.Common
{
    public class TagBase
    {
        [XmlAttribute("tag")]
        public string Tag { get; set; }
    }
}
