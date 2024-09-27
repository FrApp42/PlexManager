using PlexManager.View;

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
        }
    }
}
