using Newtonsoft.Json;

namespace CosmosSample.Domain
{
    /// <summary>
    /// todo item
    /// </summary>
    public class TodoItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = default!;

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = default!;

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }=default!;

        [JsonProperty(PropertyName = "isComplete")]
        public bool Completed { get; set; }
    }
}
