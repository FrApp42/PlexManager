using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PlexAPI;
using PlexAPI.Models.Servers;
using PlexAPI.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PlexManager.ViewModels.Servers
{
    [QueryProperty(nameof(ServerJson), "server")]
    public partial class ServerViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private bool _isLoading = true;

        [ObservableProperty]
        private string _serverJson;

        [ObservableProperty]
        private Server _server;

        

        IPlexAPI _plexAPI;

        public ServerViewModel(IPlexAPI plexAPI)
        {
            _plexAPI = plexAPI;
        }

        partial void OnServerJsonChanged(string value)
        {
            Server = JsonConvert.DeserializeObject<Server>(value);
        }

        public async void Loaded(object? sender, NavigatedToEventArgs e)
        {
            Initialize();
        }

        private async Task Initialize()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (string.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(Views.Tokens.ClaimPage));
                return;
            }

            IsLoading = true;

            try
            {
                await LoadCapabilities();
                await LoadLibrairies();
                await LoadUsers();
            }
            finally
            {
                IsLoading = false;
            }
            //List<Task> loaders = new List<Task>();
            //loaders.Add(LoadServerCapabilities());
            //loaders.Add(LoadServerLibraries());
            //loaders.Add(LoadUsers());

            //Task.WaitAll(loaders.ToArray());
            //await Task.Run(LoadServerCapabilities);
            //await Task.Run(LoadServerLibraries);
            //await Task.Run(LoadUsers);

            _isInitialized = true;
        }

        public void Unloaded(object? sender, NavigatedFromEventArgs e)
        {
            IsLoading = true;
        }

        #region Capabilities

        [ObservableProperty]
        private ServerCapabilities _capabilities;

        private async Task LoadCapabilities()
        {
            try
            {
                Capabilities = await _plexAPI.GetServerCapabilities(Server);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                Capabilities = new ServerCapabilities(); // Initialize to avoid null reference
            }
        }

        #endregion

        #region Librairies

        [ObservableProperty]
        private bool _isLoadingLibraries = false;

        [ObservableProperty]
        private ObservableCollection<Library> _libraries = new();


        //[ObservableProperty]
        //private List<ServerLibraryParameter> _librariesWithServer = [];

        [RelayCommand]
        private async Task LoadLibrairies()
        {
            IsLoadingLibraries = true;
            try
            {
                Libraries.Clear();
                ServerLibraries serverLibs = await _plexAPI.GetServerLibraries(Server);
                Libraries = serverLibs.Libraries != null 
                    ? new ObservableCollection<Library>(serverLibs.Libraries.OrderBy(l => l.Title)) 
                    : new ObservableCollection<Library>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);   
                //LibrariesWithServer = [];
            }
            finally
            {
                IsLoadingLibraries = false;
            }
            
        }

        //private async Task LoadServerLibraries()
        //{
        //    try
        //    {
        //        ServerLibraries libraries = await _plexAPI.GetServerLibraries(Server);

        //        LibrariesWithServer.Clear();

        //        foreach (Library library in libraries.Libraries)
        //        {
        //            LibrariesWithServer.Add(new ServerLibraryParameter
        //            {
        //                Server = Server,
        //                Library = library
        //            });
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        LibrariesWithServer = [];
        //    }
        //}

        //[RelayCommand]
        //private async Task UpdateAllLibraries(Server server)
        //{
        //    bool updateSuccess = await _plexAPI.UpdateAllServerLibraries(server);
        //    string message;

        //    if (updateSuccess)
        //        message = "All libraries are being updated";
        //    else
        //        message = "Error while trying to update all libraries";

        //    CancellationTokenSource cancellationTokenSource = new();

        //    IToast toast = Toast.Make(message, ToastDuration.Short, 14);
        //    await toast.Show(cancellationTokenSource.Token);
        //}

        [RelayCommand]
        private async Task NavigateToSingleLibrary(Library parameter)
        {
            string serverJson = JsonConvert.SerializeObject(Server);
            string libraryJson = JsonConvert.SerializeObject(parameter);

            await Shell.Current.GoToAsync($"{nameof(Views.Servers.LibraryPage)}?server={Uri.EscapeDataString(serverJson)}&library={Uri.EscapeDataString(libraryJson)}");
        }

        #endregion

        #region Users

        [ObservableProperty]
        private bool _isLoadingUsers = false;

        [ObservableProperty]
        private ServerUserList _userList;

        [ObservableProperty]
        private ObservableCollection<User> _users = new ();

        [RelayCommand]
        private async Task LoadUsers()
        {
            try
            {
                IsLoadingUsers = true;
                Users.Clear();

                ServerUserList userList = await _plexAPI.GetServerUserList(Server);
                //userList.Users = [.. userList
                //    .Users
                //    .Where(u => !string.IsNullOrEmpty(u.Name))
                //    .OrderBy(u => u.Name)];

                //UserList = userList;

                Users = new ObservableCollection<User>(
                    userList.Users
                        .Where(u => !string.IsNullOrEmpty(u.Name))
                        .OrderBy(u => u.Name)
                );

            }
            catch (Exception ex)
            {
                    Debug.WriteLine(ex);
            }
            finally
            {
                IsLoadingUsers = false;
            }
        }

        #endregion

        [RelayCommand]
        private async Task CopyMachineId(string machineId)
        {
            await Clipboard.Default.SetTextAsync(machineId);

            CancellationTokenSource cancellationTokenSource = new();

            IToast toast = Toast.Make("Machine ID copied to clipboard", ToastDuration.Short, 14);
            await toast.Show(cancellationTokenSource.Token);
        }

        
    }
}
