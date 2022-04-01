using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosSample.MauiCRM.Pages;

internal static class PagesExtensions
{
    public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
    {
        // main tabs of the app
        builder.Services.AddSingleton<DashboardPage>();
        builder.Services.AddSingleton<SalesPage>();
        builder.Services.AddSingleton<MarketingPage>();
        builder.Services.AddSingleton<SettingsPage>();


        return builder;
    }
}

