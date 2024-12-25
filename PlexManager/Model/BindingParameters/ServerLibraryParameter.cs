using PlexAPI;
using PlexAPI.Models.Servers;

namespace PlexManager.Model.BindingParameters
{
    public class ServerLibraryParameter
    {
        public Server Server { get; set; }

        public Library Library { get; set; }
    }
}
