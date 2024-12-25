using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    [XmlRoot("MediaContainer")]
    public class LibraryBase
    {
        [XmlAttribute("size")]
        public int Size { get; set; }

        [XmlAttribute("allowSync")]
        public int AllowSync { get; set; }

        [XmlAttribute("art")]
        public string Art { get; set; }

        [XmlAttribute("content")]
        public string Content { get; set; }

        [XmlAttribute("identifier")]
        public string Identifier { get; set; }

        [XmlAttribute("librarySectionID")]
        public int LibrarySectionId { get; set; }

        [XmlAttribute("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; }

        [XmlAttribute("librarySectionUUID")]
        public string LibrarySectionUUID { get; set; }

        [XmlAttribute("mediaTagPrefix")]
        public string MediaTagPrefix { get; set; }

        [XmlAttribute("mediaTagVersion")]
        public long MediaTagVersion { get; set; }

        [XmlAttribute("thumb")]
        public string Thumb { get; set; }

        [XmlAttribute("title1")]
        public string Title1 { get; set; }

        [XmlAttribute("title2")]
        public string Title2 { get; set; }

        [XmlAttribute("viewGroup")]
        public string ViewGroup { get; set; }
    }
}
