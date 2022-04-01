using CosmosSample.MauiCRM.Pages;

namespace CosmosSample.MauiCRM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureEssentials()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .ConfigureServices()
                .ConfigurePages();

            return builder.Build();
        }
    }
}
