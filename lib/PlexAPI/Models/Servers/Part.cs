using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    public class Part
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("duration")]
        public long Duration { get; set; }

        [XmlAttribute("file")]
        public string File { get; set; }

        [XmlAttribute("size")]
        public long Size { get; set; }

        [XmlAttribute("container")]
        public string Container { get; set; }

        [XmlAttribute("hasThumbnail")]
        public int HasThumbnail { get; set; }

        [XmlAttribute("videoProfile")]
        public string VideoProfile { get; set; }
    }
}
