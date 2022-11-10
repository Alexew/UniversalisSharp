using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.InfoEndpoint.Models
{
    public class DataCenter
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("region")]
        public string? Region { get; set; }

        [JsonProperty("worlds")]
        public int[]? Worlds { get; set; }
    }
}