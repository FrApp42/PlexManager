using PlexAPI.Models.Servers;

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
    }
}
