using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    [XmlRoot("MediaContainer")]
    public class LibraryMovie : LibraryBase
    {
        [XmlElement("Video")]
        public List<LibraryMovieVideo> Videos { get; set; }
    }
}
