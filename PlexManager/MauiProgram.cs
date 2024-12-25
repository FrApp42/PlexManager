using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MauiIcons.Material;
using PlexAPI;
using PlexManager.View;
using PlexManager.ViewModel;
//using Plex.ServerApi;
//using Plex.ServerApi.Clients.Interfaces;
//using Plex.ServerApi.Clients;
//using Plex.ServerApi.Api;
//using Plex.Api.Factories;
//using Plex.Library.Factories;

namespace PlexManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiApp<App>()
                .UseMaterialMauiIcons()
                .UsePlexAPI()
            ;

            //var apiOptions = new ClientOptions
            //{
            //    Product = "PlexManager",
            //    DeviceName = "Android",
            //    ClientId = "PlexManager",
            //    Platform = "Web",
            //    Version = "v1"
            //};

            var services = builder.Services;
            services
                .AddSingleton<IConnectivity>(Connectivity.Current)
                .AddSingleton<ServersPage>()
                .AddSingleton<ServersViewModel>()
                .AddSingleton<AboutPage>()
                .AddSingleton<AboutViewModel>()
                .AddSingleton<ClaimTokenPage>()
                .AddSingleton<ClaimTokenViewModel>()
                .AddSingleton<SingleServerPage>()
                .AddSingleton<SingleServerViewModel>()
                .AddSingleton<SettingsPage>()
                .AddSingleton<SettingsViewModel>()
                .AddSingleton<SingleLibraryPage>()
                .AddSingleton<SingleLibraryViewModel>()
                //.AddSingleton(apiOptions)
                //.AddTransient<IPlexServerClient, PlexServerClient>()
                //.AddTransient<IPlexAccountClient, PlexAccountClient>()
                //.AddTransient<IPlexLibraryClient, PlexLibraryClient>()
                //.AddTransient<IApiService, ApiService>()
                //.AddTransient<IPlexFactory, PlexFactory>()
                //.AddTransient<IPlexRequestsHttpClient, PlexRequestsHttpClient>()
            ;

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
