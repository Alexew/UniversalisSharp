using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.InfoEndpoint.Models
{
    public class UploadHistory
    {
        [JsonProperty("uploadCountByDay")]
        public int[]? UploadCountByDay { get; set; }
    }
}