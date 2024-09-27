using System.Xml.Serialization;

namespace PlexAPI
{
    [XmlRoot(ElementName = "MediaContainer")]
    public class Servers
    {
        [XmlElement(ElementName = "Server")]
        public List<Server> Server { get; set; }

        [XmlAttribute(AttributeName = "friendlyName")]
        public string FriendlyName { get; set; }

        [XmlAttribute(AttributeName = "identifier")]
        public string Identifier { get; set; }

        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        [XmlAttribute(AttributeName = "size")]
        public int Size { get; set; }
    }
}
