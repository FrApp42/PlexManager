using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    [XmlRoot("MediaContainer")]
    public class ServerLibraries
    {
        [XmlAttribute("size")]
        public int Size { get; set; }

        [XmlAttribute("allowSync")]
        public int AllowSync { get; set; }

        [XmlAttribute("identifier")]
        public string Identifier { get; set; }

        [XmlAttribute("mediaTagPrefix")]
        public string MediaTagPrefix { get; set; }

        [XmlAttribute("mediaTagVersion")]
        public long MediaTagVersion { get; set; }

        [XmlAttribute("title1")]
        public string Title1 { get; set; }

        [XmlElement("Directory")]
        public List<Library> Libraries { get; set; }
    }
}
