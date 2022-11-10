using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.InfoEndpoint.Models
{
    public class UploaderUploadCount
    {
        [JsonProperty("sourceName")]
        public string? SourceName { get; set; }

        [JsonProperty("uploadCount")]
        public int UploadCount { get; set; }
    }
}