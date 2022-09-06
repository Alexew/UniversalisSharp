using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.MarketEndpoint.Models
{
	public class RecentlyItem
	{
		[JsonProperty("itemID")]
		public int Id { get; set; }

		[JsonProperty("lastUploadTime")]
		public long LastUploadTime { get; set; }

		public DateTimeOffset LastUpload
		{
			get
			{
				return DateTimeOffset.FromUnixTimeMilliseconds(LastUploadTime);
			}
		}

		[JsonProperty("worldID")]
		public int WorldId { get; set; }

		[JsonProperty("worldName")]
		public string? WorldName { get; set; }
	}
}
