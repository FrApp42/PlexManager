using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlexAPI;
using PlexAPI.Services.Interfaces;
using PlexManager.Views;

namespace PlexManager.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        IPlexAPI _plexAPI;

        public SettingsViewModel(IPlexAPI plexAPI)
        {
            _plexAPI = plexAPI;
        }

        [ObservableProperty]
        private Account _account;

        public async void Loaded(object? sender, NavigatedToEventArgs e)
        {
            string? oauthToken = await SecureStorage.Default.GetAsync("oauth_token");

            if (string.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(Views.Tokens.ClaimPage));
                return;
            }

            Account = await _plexAPI.GetAccount();

        }

        public void Unloaded(object? sender, NavigatedFromEventArgs e)
        {
        }

        [RelayCommand]
        private async Task Logout()
        {
            SecureStorage.Default.Remove("oauth_token");
            await Shell.Current.GoToAsync(nameof(Views.Tokens.ClaimPage));
        }
    }
}
