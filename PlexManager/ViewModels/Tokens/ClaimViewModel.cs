using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlexAPI.Services.Interfaces;
using PlexManager.Views;

namespace PlexManager.ViewModels.Tokens
{
    public partial class ClaimViewModel : ObservableObject
    {
        IPlexAPI _plexAPI;

        public ClaimViewModel(IPlexAPI plexAPI)
        {
            _plexAPI = plexAPI;
        }

        [ObservableProperty]
        string _username = string.Empty;

        [ObservableProperty]
        string _password = string.Empty;

        [ObservableProperty]
        string? _mfa;

        [RelayCommand]
        async Task RunAuth()
        {

            try
            {
                bool isConnected = await _plexAPI.Auth(Username, Password, Mfa);

                if (isConnected)
                {
                    await SecureStorage.Default.SetAsync("oauth_token", _plexAPI?.GetToken());
                    await Shell.Current.GoToAsync($"//{nameof(ServersPage)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
