using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    public class Library
    {
        [XmlAttribute("allowSync")]
        public int AllowSync { get; set; }

        [XmlAttribute("art")]
        public string Art { get; set; }

        [XmlAttribute("composite")]
        public string Composite { get; set; }

        [XmlAttribute("filters")]
        public int Filters { get; set; }

        [XmlAttribute("refreshing")]
        public int Refreshing { get; set; }

        [XmlAttribute("thumb")]
        public string Thumb { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("agent")]
        public string Agent { get; set; }

        [XmlAttribute("scanner")]
        public string Scanner { get; set; }

        [XmlAttribute("language")]
        public string Language { get; set; }

        [XmlAttribute("uuid")]
        public string Uuid { get; set; }

        [XmlAttribute("updatedAt")]
        public long UpdatedAt { get; set; }

        [XmlAttribute("createdAt")]
        public long CreatedAt { get; set; }

        [XmlAttribute("scannedAt")]
        public long ScannedAt { get; set; }

        [XmlAttribute("content")]
        public int Content { get; set; }

        [XmlAttribute("directory")]
        public int DirectoryAttribute { get; set; }

        [XmlAttribute("contentChangedAt")]
        public long ContentChangedAt { get; set; }

        [XmlAttribute("hidden")]
        public int Hidden { get; set; }

        [XmlElement("Location")]
        public Location Location { get; set; }
    }
}
