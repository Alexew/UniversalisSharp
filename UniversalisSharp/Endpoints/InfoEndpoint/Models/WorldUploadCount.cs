using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.InfoEndpoint.Models
{
    public class WorldUploadCount
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("proportion")]
        public decimal Proportion { get; set; }
    }
}