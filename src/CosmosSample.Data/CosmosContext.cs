using Microsoft.EntityFrameworkCore;
using CosmosSample.Domain;
using CosmosSample.Domain.Entities;
using CosmosSample.Domain.Entities.Abstract;

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
        /// test items
        /// </summary>
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        /// <summary>
        /// users
        /// </summary>
        public DbSet<MemberEntity> MemberEntities => Set<MemberEntity>();

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

            modelBuilder.Entity<MemberEntity>(entity =>
            {
                entity.HasPartitionKey(e => e.Email);
                entity.ToContainer(nameof(MemberEntity));
            });
            base.OnModelCreating(modelBuilder);
        }

        /// <inheritdoc/>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ValidateEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        /// <inheritdoc/>
        public override int SaveChanges()
        {
            ValidateEntities();
            return base.SaveChanges();
        }

        /// <inheritdoc/>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ValidateEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ValidateEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        /// <summary>
        /// Calibrate the model and assign initial values
        /// </summary>
        /// <exception cref="ValidationException"></exception>
        private void ValidateEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                    .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in modifiedEntries)
            {
                if (entity.Entity is ValidatableObject validatableObject)
                {
                    var validationResults = validatableObject.Validate();
                    if (validationResults.Any())
                    {
                        throw new ValidationException(entity.Entity.GetType(), validationResults);
                    }
                }
            }

            var now = DateTimeOffset.Now;
            foreach (var entity in modifiedEntries.Where(x => x.State == EntityState.Added))
            {
                if (entity.Entity is EntityBase entityBase && entityBase.CreatedOn == default)
                {
                    entityBase.CreatedOn = now;
                }
            }

            foreach (var entity in modifiedEntries.Where(x => x.State == EntityState.Modified))
            {
                if (entity.Entity is EntityBase entityBase)
                {
                    entityBase.UpdatedOn = now;
                }
            }
        }
    }
}
