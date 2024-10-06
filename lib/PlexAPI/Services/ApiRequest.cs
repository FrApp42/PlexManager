using FrApp42.Web.API;

namespace PlexAPI.Services
{
    internal class ApiRequest : Request
    {
        public ApiRequest(string url) : base(url)
        {
        }

        public ApiRequest(string url, HttpMethod method) : base(url, method)
        {
        }

        public ApiRequest AddPlexToken(string authToken)
        {
            RequestHeaders.Add("X-Plex-Token", authToken);
            return this;
        }

        public ApiRequest AddPlexClientIdentifier()
        {
            RequestHeaders.Add("X-Plex-Client-Identifier", "PlexManager");
            return this;
        }
    }
}
