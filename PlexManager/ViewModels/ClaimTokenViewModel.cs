using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlexAPI.Services.Interfaces;
using PlexManager.Views;

namespace PlexManager.ViewModels
{
    public partial class ClaimTokenViewModel : ObservableObject
    {
        IPlexAPI _plexAPI;

        public ClaimTokenViewModel(IPlexAPI plexAPI)
        {
            _plexAPI = plexAPI;
        }

        [ObservableProperty]
        string _username = string.Empty;

        [ObservableProperty]
        string _password = string.Empty;

        [ObservableProperty]
        int? _mfa;

        [RelayCommand]
        async Task RunAuth()
        {

            try
            {
                bool isConnected = await _plexAPI.Auth(Username, Password, Mfa.ToString());

                if (isConnected)
                {
                    await SecureStorage.Default.SetAsync("oauth_token", _plexAPI?.GetToken());
                    await Shell.Current.GoToAsync(nameof(ServersPage));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //    await SecureStorage.Default.SetAsync("oauth_token", Token);
            //using(SQLiteContext db = new SQLiteContext())
            //{
            //    db.Add(new Setting()
            //    {
            //        Name = "server",
            //        Value = Server
            //    });

            //    db.Add(new Setting()
            //    {
            //        Name = "port",
            //        Value = Server
            //    });
            //}

            
        }
    }
}
