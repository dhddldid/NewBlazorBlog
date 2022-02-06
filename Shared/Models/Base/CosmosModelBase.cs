using Newtonsoft.Json;

namespace NewBlazorBlog.Shared.Models.Base
{
    public abstract class CosmosModelBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public abstract string ClassType { get; }
    }
}
