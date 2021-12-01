namespace CosmosSample.Domain.Entities.Abstract
{
    /// <summary>
    /// IEntityWithTypedId
    /// </summary>
    /// <typeparam name="TId">Primary key type.</typeparam>
    public interface IEntityWithTypedId<TId>
    {
        /// <summary>
        /// Id.
        /// </summary>
        TId Id { get; }
    }
}
