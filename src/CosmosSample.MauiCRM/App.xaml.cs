namespace CosmosSample.MauiCRM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new DesktopShell();

            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(SalesPage), typeof(SalesPage));
            Routing.RegisterRoute(nameof(MarketingPage), typeof(MarketingPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        }
    }
}
