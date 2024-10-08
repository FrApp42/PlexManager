using CommunityToolkit.Mvvm.ComponentModel;
using PlexManager.View;
using PlexAPI;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;

namespace PlexManager.ViewModel
{
    public partial class ServersViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<Server> _servers = new List<Server>();

        IPlexAPI _plexAPI;
        public ServersViewModel(IConnectivity connectivity, IPlexAPI plexAPI)
        {
            _plexAPI = plexAPI;
        }

        public async void Loaded(object sender, EventArgs e)
        {

            //if (connectivity.NetworkAccess != NetworkAccess.Internet)
            //{
            //    Shell.Current.DisplayAlert("No connectivity!",
            //        $"Please check internet and try again.", "OK");
            //    return;
            //}

            //string oauthToken = await SecureStorage.Default.GetAsync("oauth_token");
            //if (String.IsNullOrEmpty(oauthToken))
            //    await Shell.Current.GoToAsync(nameof(ClaimTokenPage));

            //if(!await _plexAPI.Ping(oauthToken))
            //    await Shell.Current.GoToAsync(nameof(ClaimTokenPage));

            string oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (String.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }

            if (!await _plexAPI.Ping(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }

            if (await _plexAPI.Auth(oauthToken))
            {
                try
                {
                    Servers = await _plexAPI.GetServers();
#if DEBUG
                    foreach (Server server in Servers)
                    {
                        Debug.WriteLine(server.Name);
                    }
#endif
                } catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                
            }            
        }

        [RelayCommand]
        private async Task NavigateToServer(Server server)
        {
            string serverJson = JsonConvert.SerializeObject(server);

            await Shell.Current.GoToAsync($"{nameof(SingleServer)}?server={Uri.EscapeDataString(serverJson)}");
        }
    }
}
