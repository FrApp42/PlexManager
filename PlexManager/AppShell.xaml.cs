using PlexManager.Views;

namespace PlexManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ServersPage), typeof(ServersPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(ClaimTokenPage), typeof(ClaimTokenPage));
            Routing.RegisterRoute(nameof(SingleServerPage), typeof(SingleServerPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(SingleLibraryPage), typeof(SingleLibraryPage));
        }
    }
}
