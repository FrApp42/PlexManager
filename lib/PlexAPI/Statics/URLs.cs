/* Unmerged change from project 'PlexAPI (net8.0-android)'
Added:
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library.Library;
*/

/* Unmerged change from project 'PlexAPI (net8.0-ios)'
Added:
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library.Library;
using PlexAPI.Models.Servers.Library.Library.Library;
*/

/* Unmerged change from project 'PlexAPI (net8.0-windows10.0.19041.0)'
Added:
using PlexAPI.Models.Servers.Library;
*/

/* Unmerged change from project 'PlexAPI (net8.0-android)'
Before:
using PlexAPI.Models.Servers.Library;
After:
using PlexAPI.Models.Servers;
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library;
*/

/* Unmerged change from project 'PlexAPI (net8.0-windows10.0.19041.0)'
Before:
using PlexAPI.Models.Servers.Library;
After:
using PlexAPI.Models.Servers;
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library;
*/
using PlexAPI.Models.Servers;

/* Unmerged change from project 'PlexAPI (net8.0-android)'
Removed:
using PlexAPI.Models.Servers.Library.Library.Library;
using PlexAPI.Models.Servers.Library.Library.Library.Library;
*/

/* Unmerged change from project 'PlexAPI (net8.0-windows10.0.19041.0)'
Removed:
using PlexAPI.Models.Servers.Library.Library.Library.Library;
*/

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
