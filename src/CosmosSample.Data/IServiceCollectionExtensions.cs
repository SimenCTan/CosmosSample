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
        /// <param name="cosmosdbName">Database name.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddCosmosDbContext(this IServiceCollection services, string connectionString,string cosmosdbName)
        {
            services.AddDbContextPool<CosmosContext>((sp, options) =>
            {
                options.UseCosmos(connectionString,cosmosdbName);
            });

            return services;
        }
    }
}
