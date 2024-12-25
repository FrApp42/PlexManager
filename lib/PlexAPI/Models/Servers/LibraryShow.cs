using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    [XmlRoot("MediaContainer")]
    public class LibraryShow : LibraryBase
    {
        [XmlAttribute("nocache")]
        public int NoCache { get; set; }

        [XmlElement("Directory")]
        public List<LibraryShowDirectory> Directories { get; set; }
    }
}
