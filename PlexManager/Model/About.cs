using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexManager.Model
{
    internal class About
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://github.com/AnthoDingo/PlexManager";
        public string License => "GNU General Public License v3.0";

        public IDictionary<string, string> Autors => new Dictionary<string, string>() {
            { "AnthoDingo", "https://github.com/AnthoDingo" }
        };
    }
}
