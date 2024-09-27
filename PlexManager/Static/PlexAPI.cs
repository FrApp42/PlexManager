using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexManager.Static
{
    internal static class PlexAPI
    {
        internal static string SignIn = "https://plex.tv/api/v2/users/signin";
        internal static string SignOut = "https://plex.tv/api/v2/users/signout";

        internal static string HomeUsers = "https://plex.tv/api/home/users";
        internal static string HomeUser = $"https://plex.tv/api/home/users/{{userId}}";

        internal static string Ping = "https://plex.tv/api/v2/ping";
        internal static string PlexServer = $"https://plex.tv/api/servers/{{machineId}}";
    }
}
