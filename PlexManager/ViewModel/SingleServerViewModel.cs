using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using PlexAPI;

namespace PlexManager.ViewModel
{
    [QueryProperty(nameof(ServerJson), "server")]
    public partial class SingleServerViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _serverJson;

        [ObservableProperty]
        private Server _server;

        IPlexAPI _plexAPI;

        public SingleServerViewModel(IPlexAPI plexAPI)
        {
            _plexAPI = plexAPI;

            
        }

        partial void OnServerJsonChanged(string value)
        {
            Server = JsonConvert.DeserializeObject<Server>(value);
        }

        private async void LoadServerData()
        {
            await LoadServerIdentity();
        }

        private async Task LoadServerIdentity()
        {

        }
    }
}
