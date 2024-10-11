using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlexManager.View;

namespace PlexManager.ViewModel
{
    public partial class SettingsViewModel : ObservableObject
    {
        public void Loaded(object? sender, NavigatedToEventArgs e)
        {
        }

        public void Unloaded(object? sender, NavigatedFromEventArgs e)
        {
        }

        [RelayCommand]
        private async Task Logout()
        {
            SecureStorage.Default.Remove("oauth_token");
            await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
        }
    }
}
