using PlexManager.Views;
using PlexManager.Views.Servers;
using PlexManager.Views.Tokens;

namespace PlexManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Global routes for navigation
            //Routing.RegisterRoute(nameof(ServersPage), typeof(ServersPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));

            // Token claim page
            Routing.RegisterRoute(nameof(ClaimPage), typeof(ClaimPage));

            // Server Pages
            Routing.RegisterRoute(nameof(ServerPage), typeof(ServerPage));
            Routing.RegisterRoute(nameof(LibraryPage), typeof(LibraryPage));            
        }
    }
}
