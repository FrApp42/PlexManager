using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PlexAPI;
using PlexAPI.Models.Servers;
using PlexAPI.Services.Interfaces;
using PlexManager.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PlexManager.ViewModels.Servers
{
    [QueryProperty(nameof(ServerJson), "server")]
    [QueryProperty(nameof(LibraryJson), "library")]
    public partial class LibraryViewModel : ObservableObject
    {
        #region JSON Properties
        [ObservableProperty]
        private string _serverJson;

        [ObservableProperty]
        private string _libraryJson;
        #endregion

        [ObservableProperty]
        private bool _isLoading = true;

        [ObservableProperty]
        private Server _server;

        [ObservableProperty]
        private Library _library;

        [ObservableProperty]
        private string _pageName;

        IPlexAPI _plexAPI;

        public LibraryViewModel(IPlexAPI plexAPI)
        {
            _plexAPI = plexAPI;
        }

        #region Quick Actions

        [RelayCommand]
        private async Task ScanLibrary()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (string.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(Views.Tokens.ClaimPage));
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
                await Shell.Current.GoToAsync(nameof(Views.Tokens.ClaimPage));
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
                await Shell.Current.GoToAsync(nameof(Views.Tokens.ClaimPage));
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

        #endregion

        partial void OnServerJsonChanged(string value)
        {
            Server = JsonConvert.DeserializeObject<Server>(value);
        }

        partial void OnLibraryJsonChanged(string value)
        {
            Library = JsonConvert.DeserializeObject<Library>(value);
        }

        public async void Loaded(object? sender, NavigatedToEventArgs e)
        {
            switch (Library.Type)
            {
                case "movie":
                    PageName = $"{Server.Name} - {Library.Title} (Movies)";
                    Task.Run(async () => await LoadMovies());
                    break;
                case "show":
                    PageName = $"{Server.Name} - {Library.Title} (TV Shows)";
                    Task.Run(async () => await LoadTvShows());
                    break;
                default:
                    PageName = $"{Server.Name} - {Library.Title}";
                    break;
            }
        }

        public void Unloaded(object? sender, NavigatedFromEventArgs e)
        {
            IsLoading = true;
        }


        [RelayCommand]
        private async Task RefreshLibrary()
        {
            switch (Library.Type)
            {
                case "movie":
                    await LoadMovies();
                    break;
                case "show":
                    await LoadTvShows();
                    break;
            }

        }

        [ObservableProperty]
        private ObservableCollection<Media> _medias = new();

        private async Task LoadMovies()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            Debug.WriteLine("Loading movies");
            IsLoading  = true;
            Medias.Clear();
            try
            {
                LibraryMovie libMovies = await _plexAPI.GetLibraryMovieDetails(Server, Library);
                if(libMovies == null || libMovies.Videos == null)
                {
                    Debug.WriteLine("No movies found in the library.");
                    return;
                }

                List<Media> medias = new();
                foreach (LibraryMovieVideo video in libMovies.Videos)
                {
                    if (video == null) continue;
                    Media media = new()
                    {
                        Title = video.Title,
                        ThumbUrl = new Uri($"{Server.FullUri}{video.Thumb}?X-Plex-Token={oauthToken}"),
                        Year = video.Year,
                        Duration = video.Duration,
                        Rating = video.Rating,
                        Summary = video.Summary,
                        MediaType = "Movie",
                        Key = video.Key
                    };
                    medias.Add(media);
                }

                Medias = new ObservableCollection<Media>(medias.OrderBy(m => m.Title));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading movies: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task LoadTvShows()
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            Debug.WriteLine("Loading shows");
            IsLoading = true;
            Medias.Clear();
            try
            {
                LibraryShow libShows = await _plexAPI.GetLibraryShowDetails(Server, Library);
                if (libShows == null || libShows.Directories == null)
                {
                    Debug.WriteLine("No TV shows found in the library.");
                    return;
                }

                foreach (LibraryShowDirectory show in libShows.Directories)
                {
                    if (show == null) continue;
                    Media media = new()
                    {
                        Title = show.Title,
                        ThumbUrl = new Uri($"{Server.FullUri}{show.Thumb}?X-Plex-Token={oauthToken}"),
                        Year = show.Year,
                        Duration = show.Duration,
                        Rating = show.AudienceRating,
                        Summary = show.Summary,
                        MediaType = "show",
                        Key = show.Key,
                        Season = show.ChildCount
                    };
                    Medias.Add(media);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading TV shows: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        #region Medias

        [RelayCommand]
        private async Task GoToMediaDetails(Media media)
        {
            if (media == null) return;
            string mediaJson = JsonConvert.SerializeObject(media);
            await Shell.Current.GoToAsync($"{nameof(Views.Servers.MediaPage)}?media={Uri.EscapeDataString(mediaJson)}");
        }

        #endregion
    }
}
