using PlexAPI.Services;

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
