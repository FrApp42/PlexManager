namespace PlexAPI
{
    public interface IPlexAPI
    {
        public Task<bool> Auth(string username, string password, string mfa = null);

        public Task<bool> Auth(string oauth);

        public string? GetToken();

        public Task<bool> Ping(string oauth);

        public Task<List<Server>> GetServers();
    }
}
