using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlexManager.Models;

namespace PlexManager.ViewModels
{
    public partial class AboutViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<AboutGroup> _groups =
        [
            new AboutGroup()
            {
                Name = "About",
                Items =
                [
                    new AboutItem()
                    {
                        Name = "Version",
                        Description = AppInfo.VersionString,
                        Icon = "plexmanager.png"
                    },
                    new AboutItem()
                    {
                        Name = "Source Code",
                        Icon = "github.png"
                    },
                    new AboutItem()
                    {
                        Name = "GNU General Public License v3.0",
                        Icon = "license.png",
                        Url = "https://choosealicense.com/licenses/gpl-3.0/"
                    }
                ]
            },
            new AboutGroup()
            {
                Name = "Authors",
                Items =
                [
                    new AboutItem()
                    {
                        Name = "Sikelio",
                        Description = "Original application author",
                        Icon = "https://github.com/sikelio.png?size=50",
                        Url = "https://github.com/sikelio"
                    },
                    new AboutItem()
                    {
                        Name = "AnthoDingo",
                        Description = "Co-Author",
                        Icon = "https://github.com/AnthoDingo.png?size=50",
                        Url = "https://github.com/AnthoDingo"
                    }
                ]
            }
        ];

        [RelayCommand]
        async Task OpenURL(string url)
        {
            if (string.IsNullOrEmpty(url))
                return;

            try
            {
                Uri uri = new Uri(url);
                await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occurred. No browser may be installed on the device.
            }
        }
    }
}
