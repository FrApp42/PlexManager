using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    public class UltraBlurColors
    {
        [XmlAttribute("topLeft")]
        public string TopLeft { get; set; }

        [XmlAttribute("topRight")]
        public string TopRight { get; set; }

        [XmlAttribute("bottomRight")]
        public string BottomRight { get; set; }

        [XmlAttribute("bottomLeft")]
        public string BottomLeft { get; set; }
    }
}
