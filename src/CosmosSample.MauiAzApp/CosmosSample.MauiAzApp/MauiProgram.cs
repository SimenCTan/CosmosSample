using Microsoft.AspNetCore.Components.WebView.Maui;
using CosmosSample.MauiAzApp.Data;

namespace CosmosSample.MauiAzApp;

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
        builder.Services.AddHttpClient("azfunction", c =>
        {
            c.BaseAddress = new Uri("your-azure-function-url");
            c.DefaultRequestHeaders.Add("Accept", "application/json");
            c.DefaultRequestHeaders.Add("User-Agent", "Cosmos-Sample");
        });
		return builder.Build();
	}
}
