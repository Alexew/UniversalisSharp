using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.InfoEndpoint.Models
{
    public class World
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}