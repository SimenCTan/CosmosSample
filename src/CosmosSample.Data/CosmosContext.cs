using Microsoft.EntityFrameworkCore;
using CosmosSample.Domain;

namespace CosmosSample.Data
{
    public class CosmosContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CosmosContext"/>.
        /// </summary>
        /// <param name="options">Options for this context.</param>
        public CosmosContext(DbContextOptions<CosmosContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 会员信息
        /// </summary>
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        /// <summary>
        ///  Configure the model that maps the domain to the backend.
        /// </summary>
        /// <param name="modelBuilder">The API for model configuration.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.HasDefaultContainer(nameof(CosmosContext));

            modelBuilder.Entity<TodoItem>(entity => {
                entity.HasNoDiscriminator();
                entity.HasPartitionKey(e => e.Name);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
