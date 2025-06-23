using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using PlexAPI;
using PlexManager.Models;
using System.Diagnostics;

namespace PlexManager.ViewModels.Servers
{
    [QueryProperty(nameof(MediaJson), "media")]
    public partial class MediaViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _mediaJson;

        [ObservableProperty]
        private Media _media;

        [ObservableProperty]
        private bool _isTvShow = false;

        partial void OnMediaJsonChanged(string value)
        {
            try
            {
                Media = JsonConvert.DeserializeObject<Media>(value);

                IsTvShow = Media.MediaType == "show" ? true : false ;
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization errors
                Debug.WriteLine($"Error deserializing Media JSON: {ex.Message}");
                Media = new Media(); // Initialize to an empty Media object on error
            }

        }

        public async void Loaded(object? sender, NavigatedToEventArgs e)
        {
            
        }

    }
}
