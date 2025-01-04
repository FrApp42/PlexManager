using PlexAPI.Services.Interfaces;
using PlexManager.Views;

namespace PlexManager
{
    public partial class MainPage : ContentPage
    {
        IPlexAPI _plexAPI;

        public MainPage(IPlexAPI plexAPI)
        {
            InitializeComponent();
            _plexAPI = plexAPI;
            NavigatedTo += Loaded;
            
        }

        private async void Loaded(object sender, EventArgs e)
        {
            string oauthToken = await SecureStorage.Default.GetAsync("oauth_token");
            if (String.IsNullOrEmpty(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }
                

            if (!await _plexAPI.Ping(oauthToken))
            {
                await Shell.Current.GoToAsync(nameof(ClaimTokenPage));
                return;
            }

            Shell.Current.GoToAsync(nameof(ServersPage));
        }
    }

}
