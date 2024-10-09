using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    [XmlRoot("MediaContainer")]
    public class ServerUserList
    {
        [XmlAttribute("size")]
        public int Size { get; set; }

        [XmlAttribute("identifier")]
        public string Identifier { get; set; }

        [XmlElement("Account")]
        public List<User> Users { get; set; }
    }
}
