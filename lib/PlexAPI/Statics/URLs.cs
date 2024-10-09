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
    }
}
