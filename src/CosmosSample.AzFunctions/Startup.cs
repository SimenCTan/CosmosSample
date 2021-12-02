
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosSample.Data;
using CosmosSample.Domain.Configurations;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(CosmosSample_AzFunctions.Startup))]
namespace CosmosSample_AzFunctions
{
    public class Startup : FunctionsStartup
    {
        /// <inheritdoc/>
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();

            builder.ConfigurationBuilder
                .SetBasePath(Path.Combine(context.ApplicationRootPath, "Configs"))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddJsonFile($"appsettings.{context.EnvironmentName}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
        }

        /// <inheritdoc/>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
            builder.Services.AddCosmosDbContext(configuration.GetConnectionString("CosmosConnectionString"),
                configuration.GetConnectionString("CosmosDBName"));
            builder.Services.AddAutoMapper(typeof(Startup));
        }


    }
}
