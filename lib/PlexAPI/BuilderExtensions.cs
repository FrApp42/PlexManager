using PlexAPI.Services;
using PlexAPI.Services.Interfaces;

namespace PlexAPI
{
    public static class BuilderExtensions
    {
        public static MauiAppBuilder UsePlexAPI(this MauiAppBuilder builder)
        {
            IServiceCollection services = builder.Services;
            services
                .AddSingleton<IPlexAPI, PlexAPIService>()
                ;

            return builder;
        }


    }
}
