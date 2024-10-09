using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    public class User
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("defaultAudioLanguage")]
        public string DefaultAudioLanguage { get; set; }

        [XmlAttribute("autoSelectAudio")]
        public int AutoSelectAudio { get; set; }

        [XmlAttribute("defaultSubtitleLanguage")]
        public string DefaultSubtitleLanguage { get; set; }

        [XmlAttribute("subtitleMode")]
        public int SubtitleMode { get; set; }

        [XmlAttribute("thumb")]
        public string Thumb { get; set; }
    }
}
