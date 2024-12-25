
/* Unmerged change from project 'PlexAPI (net8.0-android)'
Before:
using System.Xml.Serialization;
After:
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library.Library;
using System.Xml.Serialization;
*/

/* Unmerged change from project 'PlexAPI (net8.0-ios)'
Before:
using System.Xml.Serialization;
After:
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library.Library;
using PlexAPI.Models.Servers.Library.Library.Library;
using System.Xml.Serialization;
*/

/* Unmerged change from project 'PlexAPI (net8.0-windows10.0.19041.0)'
Before:
using System.Xml.Serialization;
After:
using PlexAPI.Models.Servers.Library;
using System.Xml.Serialization;
*/

/* Unmerged change from project 'PlexAPI (net8.0-android)'
Before:
using PlexAPI.Models.Servers.Library.Library;
using PlexAPI.Models.Servers.Library.Library.Library;
using PlexAPI.Models.Servers.Library.Library.Library.Library;
using System.Xml.Serialization;
After:
using PlexAPI.Models.Servers;
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library.Library;
using System.Xml.Serialization;
*/

/* Unmerged change from project 'PlexAPI (net8.0-windows10.0.19041.0)'
Before:
using PlexAPI.Models.Servers.Library.Library;
After:
using PlexAPI.Models.Servers;
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library.Library;
*/

/* Unmerged change from project 'PlexAPI (net8.0-windows10.0.19041.0)'
Before:
using PlexAPI.Models.Servers.Library.Library.Library.Library;
using System.Xml.Serialization;
After:
using System.Xml.Serialization;
*/
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
