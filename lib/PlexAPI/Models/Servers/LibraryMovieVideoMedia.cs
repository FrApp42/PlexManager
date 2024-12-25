using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    public class LibraryMovieVideoMedia
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("duration")]
        public long Duration { get; set; }

        [XmlAttribute("bitrate")]
        public int Bitrate { get; set; }

        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        [XmlAttribute("aspectRatio")]
        public string AspectRatio { get; set; }

        [XmlAttribute("audioChannels")]
        public int AudioChannels { get; set; }

        [XmlAttribute("audioCodec")]
        public string AudioCodec { get; set; }

        [XmlAttribute("videoCodec")]
        public string VideoCodec { get; set; }

        [XmlAttribute("videoResolution")]
        public string VideoResolution { get; set; }

        [XmlAttribute("container")]
        public string Container { get; set; }

        [XmlAttribute("videoFrameRate")]
        public string VideoFrameRate { get; set; }

        [XmlAttribute("videoProfile")]
        public string VideoProfile { get; set; }

        [XmlElement("Part")]
        public Part Part { get; set; }
    }
}
