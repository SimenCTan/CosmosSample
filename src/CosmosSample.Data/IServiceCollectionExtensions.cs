using CosmosSample.Domain.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace CosmosSample.Data
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Add db context.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="connectionString">Database connection string.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddCosmosDbContext(this IServiceCollection services)
        {
            services.AddDbContextPool<CosmosContext>((sp, options) =>
            {
                var cosmosOptions = sp
                       .GetRequiredService<IOptions<CosmosOptions>>()
                       .Value;

                // for maui
                //cosmosOptions = new CosmosOptions
                //{
                //    EndPoint = "",
                //    AccessKey = "",
                //    DatabaseName = "ToDoList"
                //};

                options.UseCosmos(cosmosOptions.EndPoint,
                       cosmosOptions.AccessKey,
                       cosmosOptions.DatabaseName);
            });

            return services;
        }
    }
}
