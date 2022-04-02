namespace CosmosSample.MauiCRM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Config.IsDesktop)
            {
                MainPage = new DesktopShell();
            }
            else
            {
                MainPage = new MobileShell();
            }

            // register contentpage
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(SalesPage), typeof(SalesPage));
            Routing.RegisterRoute(nameof(MarketingPage), typeof(MarketingPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        }
    }
}
