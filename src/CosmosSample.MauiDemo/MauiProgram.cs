using CosmosSample.Data;
using CosmosSample.Domain.Configurations;
using CosmosSample.MauiDemo.Data;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace CosmosSample.MauiDemo
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
                .RegisterBlazorMauiWebView()
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});
			builder.Services.AddBlazorWebView();
			builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.Configure<CosmosOptions>(builder.Configuration.GetSection(nameof(CosmosOptions)));
            builder.Services.AddCosmosDbContext();
            var host = builder.Build();
            return host;
		}
	}
}
