using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.MarketEndpoint.Models
{
	public class LeastRecentlyUpdatedResponse
	{
		public LeastRecentlyUpdatedResponse()
		{
			Items = new List<RecentlyItem>();
		}

		[JsonProperty("items")]
		public IList<RecentlyItem> Items { get; set; }
	}
}