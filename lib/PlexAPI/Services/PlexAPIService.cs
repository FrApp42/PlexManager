using FrApp42.Web.API;
using PlexAPI.Models.Account;
using PlexAPI.Models.Servers;
using PlexAPI.Statics;
using System.Net;
using System.Net.NetworkInformation;

namespace PlexAPI.Services
{
    public class PlexAPIService : IPlexAPI
    {

        private Account _account;
        private List<Server> _servers;

        public async Task<bool> Auth(string username, string password, string mfa = null)
        {
            SignIn signIn = new SignIn() 
            {
                login = username,
                password = password,
                verificationCode = mfa
            };

            ApiRequest request = new ApiRequest(URLs.SignIn);
            request
                .AddPlexClientIdentifier()
                .AcceptJson()
                .AddJsonBody(signIn);

            return ValidateAccount(await request.Run<Account>());
        }

        public async Task<bool> Auth(string oauth)
        {

            if (await Ping(oauth))
            {
                ApiRequest request = new ApiRequest(URLs.User);
                request
                    .AddPlexClientIdentifier()
                    .AddPlexToken(oauth)
                    .AcceptJson();

                return ValidateAccount(await request.Run<Account>());
            }           

            return false;
        }

        private bool ValidateAccount(Result<Account> result)
        {

            if (result.StatusCode == (int)HttpStatusCode.OK || result.StatusCode == (int)HttpStatusCode.Created)
            {
                _account = result.Value;
                return true;
            }

            return false;
        }

        public string? GetToken()
        {
            if (_account != null)
                return _account.AuthToken;

            return null;
        }

        public async Task<bool> Ping(string oauth)
        {
            ApiRequest request = new ApiRequest(URLs.Ping);
            request
                .AddPlexToken(oauth)
                .AddPlexClientIdentifier()
                .AcceptJson();

            Result<Ping> result = await request.Run<Ping>();

            if (result.StatusCode == (int)HttpStatusCode.OK)
                return true;

            return false;
        }

        public async Task<List<Server>> GetServers()
        {
            if (_account == null)
                throw new Exception("You must Authenticate first !");

            ApiRequest request = new ApiRequest(URLs.Servers);
            request
                .AddPlexClientIdentifier()
                .AddPlexToken(_account.AuthToken);

            Result<Servers> servers = await request.Run<Servers>();

            if (servers.StatusCode == (int)HttpStatusCode.OK)
            {
                _servers = servers.Value.Server.Where(s => s.Owned == 1).ToList();
            }

            return _servers;
        }

        public async Task<ServerCapabilities?> GetServerCapabilities(Server server)
        {
            if (_account == null)
                throw new Exception("You must Authenticate first !");

            ApiRequest request = new(URLs.ServerCapabilities(server));
            request
                .AddPlexClientIdentifier()
                .AddPlexToken(_account.AuthToken);

            Result<ServerCapabilities> result = await request.Run<ServerCapabilities>();

            switch (result.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    return result.Value;
                case (int)HttpStatusCode.Unauthorized:
                default:
                    return null;
            }
        }

        public async Task<ServerLibraries?> GetServerLibraries(Server server)
        {
            if (_account == null)
                throw new Exception("You must Authenticate first !");

            ApiRequest request = new(URLs.ServerLibraries(server));
            request
                .AddPlexClientIdentifier()
                .AddPlexToken(_account.AuthToken);

            Result<ServerLibraries> result = await request.Run<ServerLibraries>();

            switch (result.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    return result.Value;
                case (int)HttpStatusCode.Unauthorized:
                default:
                    return null;
            }
        }

        public async Task<bool> UpdateAllServerLibraries(Server server)
        {
            if (_account == null)
                throw new Exception("You must Authenticate first !");

            ApiRequest request = new(URLs.UpdateAllServerLibraries(server));
            request
                .AddPlexClientIdentifier()
                .AddPlexToken(_account.AuthToken);

            Result<object> result = await request.Run<object>();

            switch (result.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    return true;
                case (int)HttpStatusCode.Unauthorized:
                default:
                    return false;
            }
        }
    }
}
