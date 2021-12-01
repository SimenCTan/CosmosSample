using Newtonsoft.Json;

namespace CosmosSample.Domain
{
    /// <summary>
    /// todo item
    /// </summary>
    public class TodoItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = default!;

        public string Description { get; set; }=default!;

        public bool Completed { get; set; }
    }
}
