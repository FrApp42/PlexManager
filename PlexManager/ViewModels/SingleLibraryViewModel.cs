using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PlexAPI;
using PlexAPI.Models.Servers;
using PlexAPI.Services.Interfaces;
using PlexManager.Views;
using static Android.Provider.MediaStore;

namespace PlexManager.ViewModels
{
    [QueryProperty(nameof(ServerJson), "server")]
    [QueryProperty(nameof(LibraryJson), "library")]
    public partial class SingleLibraryViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isLoading = true;

        [ObservableProperty]
        private string _serverJson;

        [ObservableProperty]
        private string _libraryJson;

        [ObservableProperty]
        private Server _server;

        [ObservableProperty]
        private Library _library;

        [ObservableProperty]
        private LibraryMovie? _libraryMovie;

        [ObservableProperty]
        private LibraryShow? _libraryTvShow;

        [ObservableProperty]
        private string _pageName;

        IPlexAPI _plexAPI;

        public SingleLibraryViewModel(IPlexAPI plexAPI)
        {
            _plexAPI = plexAPI;
        }

        partial void OnServerJsonChanged(string value)
        {
            Server = JsonConvert.DeserializeObject<Server>(value);
        }

        partial void OnLibraryJsonChanged(string value)
        {
            Library = JsonConvert.DeserializeObject<Library>(value);
        }

        partial void OnServerChanged(Server value)
        {
            PageName = $"{value.Name} - ...";
        }

        partial void OnLibraryChanged(Library value)
        {
            PageName = $"{Server.Name} - {value.Title}";
        }

        public async void Loaded(object? sender, NavigatedToEventArgs e)
        {
            IsLoading = true;

            try
            {
                await LoadLibraryDetails();
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

        private async Task LoadLibraryDetails()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (string.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }

            LibraryMovie = null;
            LibraryTvShow = null;

            try
            {
                switch (Library.Type)
                {
                    case "movie":
                        LibraryMovie = await _plexAPI.GetLibraryMovieDetails(Server, Library);

                        if (LibraryMovie != null)
                        {
                            foreach (LibraryMovieVideo video in LibraryMovie.Videos)
                            {
                                video.ThumbUrl = new Uri($"{Server.FullUri}{video.Thumb}?X-Plex-Token={oauthToken}");
                            }
                        }
                        break;
                    case "show":
                        LibraryTvShow = await _plexAPI.GetLibraryShowDetails(Server, Library);

                        foreach (LibraryShowDirectory directory in LibraryTvShow.Directories)
                        {
                            directory.ThumbUrl = new Uri($"{Server.FullUri}{directory.Thumb}?X-Plex-Token={oauthToken}");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        [RelayCommand]
        private async Task ScanLibrary()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (string.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }

            try
            {
                bool success = await _plexAPI.UpdateLibrary(Server, Library);

                if (success)
                {
                    CancellationTokenSource cancellationTokenSource = new();
                    IToast toast = Toast.Make("Library scan started", ToastDuration.Short, 14);
                    await toast.Show(cancellationTokenSource.Token);
                }
                else
                {
                    CancellationTokenSource cancellationTokenSource = new();
                    IToast toast = Toast.Make("An error occured", ToastDuration.Short, 14);
                    await toast.Show(cancellationTokenSource.Token);
                }
            }
            catch
            { }
        }

        [RelayCommand]
        private async Task UpdateLibraryMetadata()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (string.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }

            try
            {
                bool success = await _plexAPI.UpdateLibraryMetadata(Server, Library);

                if (success)
                {
                    CancellationTokenSource cancellationTokenSource = new();
                    IToast toast = Toast.Make("Updating of library metadata started", ToastDuration.Short, 14);
                    await toast.Show(cancellationTokenSource.Token);
                }
                else
                {
                    CancellationTokenSource cancellationTokenSource = new();
                    IToast toast = Toast.Make("An error occured", ToastDuration.Short, 14);
                    await toast.Show(cancellationTokenSource.Token);
                }
            }
            catch
            { }
        }

        [RelayCommand]
        private async Task EmptyLibraryTrash()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (string.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }

            try
            {
                bool success = await _plexAPI.EmptyLibraryTrash(Server, Library);

                if (success)
                {
                    CancellationTokenSource cancellationTokenSource = new();
                    IToast toast = Toast.Make("Library trash clear started", ToastDuration.Short, 14);
                    await toast.Show(cancellationTokenSource.Token);
                }
                else
                {
                    CancellationTokenSource cancellationTokenSource = new();
                    IToast toast = Toast.Make("An error occured", ToastDuration.Short, 14);
                    await toast.Show(cancellationTokenSource.Token);
                }
            }
            catch
            { }
        }
    }
}
