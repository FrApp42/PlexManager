using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PlexAPI;
using PlexAPI.Services.Interfaces;
using PlexManager.Static;
using PlexManager.Views;
using System.Diagnostics;

namespace PlexManager.ViewModels
{
    public partial class ServersViewModel : ObservableObject
    {

        private bool _isInitialized = false;

        [ObservableProperty]
        private bool _isLoading = false;

        [ObservableProperty]
        public List<Server> _servers = new List<Server>();

        IPlexAPI _plexAPI;
        public ServersViewModel(IConnectivity connectivity, IPlexAPI plexAPI)
        {
            _plexAPI = plexAPI;
        }

        public async void Loaded(object sender, EventArgs e)
        {
            if (!_isInitialized)
                await Initialize();
        }

        private async Task Initialize()
        {
            string oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (String.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(Views.Tokens.ClaimPage));
                return;
            }

            if (!await _plexAPI.Ping(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(Views.Tokens.ClaimPage));
                return;
            }

            await LoadServers();

            _isInitialized = true;
        }


        [RelayCommand]
        private async Task LoadServers()
        {
            string oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            IsLoading = true;
            if (await _plexAPI.Auth(oauthToken))
            {
                try
                {
                    Servers = await _plexAPI.GetServers();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                
            }
            IsLoading = false;
        }


        [RelayCommand]
        private async Task NavigateToServer(Server server)
        {
            string serverJson = JsonConvert.SerializeObject(server);

            await Shell.Current.GoToAsync($"{nameof(Views.Servers.ServerPage)}?server={Uri.EscapeDataString(serverJson)}");
        }
    }
}
