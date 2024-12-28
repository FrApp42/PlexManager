using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PlexAPI;
using PlexAPI.Models.Servers;
using PlexManager.Models.BindingParameters;
using PlexManager.Views;

namespace PlexManager.ViewModels
{
    [QueryProperty(nameof(ServerJson), "server")]
    public partial class SingleServerViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isLoading = true;

        [ObservableProperty]
        private string _serverJson;

        [ObservableProperty]
        private Server _server;

        [ObservableProperty]
        private ServerCapabilities _capabilities;

        [ObservableProperty]
        private ServerLibraries _libraries;

        [ObservableProperty]
        private List<ServerLibraryParameter> _librariesWithServer = [];

        [ObservableProperty]
        private ServerUserList _userList;

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
            IsLoading = true;

            try
            {
                await LoadServerCapabilities();
                await LoadServerLibraries();
                await LoadServerUsers();
            }
            finally
            {
                IsLoading = false;
            }
        }

        public void Unloaded(object? sender, NavigatedFromEventArgs e)
        {
            IsLoading = true;
        }

        private async Task LoadServerCapabilities()
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
            catch
            {
            }
        }

        private async Task LoadServerLibraries()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (string.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }

            try
            {
                ServerLibraries libraries = await _plexAPI.GetServerLibraries(Server);

                LibrariesWithServer.Clear();

                foreach (Library library in libraries.Libraries)
                {
                    LibrariesWithServer.Add(new ServerLibraryParameter
                    {
                        Server = Server,
                        Library = library
                    });
                }
            }
            catch
            {
            }
        }

        private async Task LoadServerUsers()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (string.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }

            try
            {
                ServerUserList userList = await _plexAPI.GetServerUserList(Server);
                userList.Users = [.. userList
                    .Users
                    .Where(u => !string.IsNullOrEmpty(u.Name))
                    .OrderBy(u => u.Name)];

                UserList = userList;
            }
            catch
            {
            }
        }

        [RelayCommand]
        private async Task CopyMachineId(string machineId)
        {
            await Clipboard.Default.SetTextAsync(machineId);

            CancellationTokenSource cancellationTokenSource = new();

            IToast toast = Toast.Make("Machine ID copied to clipboard", ToastDuration.Short, 14);
            await toast.Show(cancellationTokenSource.Token);
        }

        [RelayCommand]
        private async Task UpdateAllLibraries(Server server)
        {
            bool updateSuccess = await _plexAPI.UpdateAllServerLibraries(server);
            string message;

            if (updateSuccess)
                message = "All libraries are being updated";
            else
                message = "Error while trying to update all libraries";

            CancellationTokenSource cancellationTokenSource = new();

            IToast toast = Toast.Make(message, ToastDuration.Short, 14);
            await toast.Show(cancellationTokenSource.Token);
        }

        [RelayCommand]
        private async Task NavigateToSingleLibrary(ServerLibraryParameter parameter)
        {
            string serverJson = JsonConvert.SerializeObject(parameter.Server);
            string libraryJson = JsonConvert.SerializeObject(parameter.Library);

            await Shell.Current.GoToAsync($"{nameof(SingleLibraryPage)}?server={Uri.EscapeDataString(serverJson)}&library={Uri.EscapeDataString(libraryJson)}");
        }
    }
}
