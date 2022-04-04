using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosSample.MauiCRM.Services
{
    internal static class ServicesExtensions
    {
        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            builder.Services.AddHttpClient<SalesService>(httpClient => {
                httpClient.BaseAddress = new Uri(Config.APIUrl);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Cosmos-Sample");
            });
            return builder;
        }
    }
}
