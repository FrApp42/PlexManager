using PlexAPI.Models.Servers;

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
using PlexAPI.Models.Servers.Library.Library;
using PlexAPI.Models.Servers.Library.Library.Library;
using PlexAPI.Models.Servers.Library.Library.Library.Library;
After:
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library.Library;
*/

/* Unmerged change from project 'PlexAPI (net8.0-windows10.0.19041.0)'
Before:
using PlexAPI.Models.Servers.Library.Library;
After:
using PlexAPI.Models.Servers.Library;
using PlexAPI.Models.Servers.Library.Library;
*/

/* Unmerged change from project 'PlexAPI (net8.0-windows10.0.19041.0)'
Removed:
using PlexAPI.Models.Servers.Library.Library.Library.Library;
*/

namespace PlexAPI
{
    public interface IPlexAPI
    {
        public Task<bool> Auth(string username, string password, string mfa = null);

        public Task<bool> Auth(string oauth);

        public string? GetToken();

        public Task<bool> Ping(string oauth);

        public Task<List<Server>> GetServers();

        public Task<ServerCapabilities?> GetServerCapabilities(Server server);

        public Task<ServerLibraries?> GetServerLibraries(Server server);

        public Task<bool> UpdateAllServerLibraries(Server server);

        public Task<ServerUserList?> GetServerUserList(Server server);

        public Task<LibraryMovie?> GetLibraryMovieDetails(Server server, Library library);

        public Task<LibraryShow?> GetLibraryShowDetails(Server server, Library library);
    }
}
