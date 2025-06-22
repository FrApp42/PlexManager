using PlexAPI.Models.Servers;

namespace PlexAPI.Statics
{
    internal class URLs
    {
        internal static string BaseURL = "https://plex.tv/api";

        internal static string SignIn = $"{BaseURL}/v2/users/signin";
        internal static string SignOut = $"{BaseURL}/v2/users/signout";
        internal static string User = $"{BaseURL}/v2/user.json";

        internal static string Servers = $"{BaseURL}/servers";

        internal static string Ping = $"{BaseURL}/v2/ping";

        internal static string ServerCapabilities(Server server)
        {
            return $"{server.Scheme}://{server.Address}:{server.Port}";
        }

        internal static string ServerLibraries(Server server)
        {
            return $"{server.Scheme}://{server.Address}:{server.Port}/library/sections";
        }

        internal static string UpdateAllServerLibraries(Server server)
        {
            return $"{server.Scheme}://{server.Address}:{server.Port}/library/sections/all/refresh";
        }

        internal static string ServerUserList(Server server)
        {
            return $"{server.Scheme}://{server.Address}:{server.Port}/accounts";
        }

        internal static string LibraryDetails(Server server, Library library)
        {
            return $"{server.Scheme}://{server.Address}:{server.Port}/library/sections/{library.Key}/all";
        }

        internal static string UpdateLibrary(Server server, Library library)
        {
            return $"{server.Scheme}://{server.Address}:{server.Port}/library/sections/{library.Key}/refresh";
        }

        internal static string EmptyLibraryTrash(Server server, Library library)
        {
            return $"{server.Scheme}://{server.Address}:{server.Port}/library/sections/{library.Key}/emptyTrash";
        }
    }
}
