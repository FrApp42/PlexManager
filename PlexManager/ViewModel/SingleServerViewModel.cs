using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PlexAPI;
using PlexAPI.Models.Servers;
using PlexManager.View;

namespace PlexManager.ViewModel
{
    [QueryProperty(nameof(ServerJson), "server")]
    public partial class SingleServerViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _serverJson;

        [ObservableProperty]
        private Server _server;

        [ObservableProperty]
        private ServerCapabilities _capabilities;

        IPlexAPI _plexAPI;

        public SingleServerViewModel(IPlexAPI plexAPI)
        {
            _plexAPI = plexAPI;
        }

        partial void OnServerJsonChanged(string value)
        {
            Server = JsonConvert.DeserializeObject<Server>(value);
        }

        public async void Loaded(object? sender, NavigatedToEventArgs e)
        {
            await LoadServerIdentity();
        }

        private async Task LoadServerIdentity()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (string.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }

            try
            {
                Capabilities = await _plexAPI.GetServerCapabilities(Server);
            }
            catch (Exception ex)
            {
            }
        }

        [RelayCommand]
        private async Task CopyMachineId(string machineId)
        {
            await Clipboard.Default.SetTextAsync(machineId);
            await Application.Current.MainPage.DisplayAlert("Machine ID", "Machine ID copied to clipboard!", "OK");
        }
    }
}
