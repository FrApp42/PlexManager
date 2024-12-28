namespace PlexManager.Models
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
