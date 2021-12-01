namespace CosmosSample.Domain.Entities.Abstract
{
    /// <summary>
    /// Entity base with typed id.
    /// </summary>
    /// <typeparam name="TId">Primary key type.</typeparam>
    public class EntityBaseWithTypedId<TId> : ValidatableObject, IEntityWithTypedId<TId>
    {
        /// <inheritdoc/>
        public virtual TId Id { get; set; } = default!;
    }
}
