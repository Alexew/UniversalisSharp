using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.MarketEndpoint.Models
{
	public class RecentlyUpdatedResponse
	{
		public RecentlyUpdatedResponse()
		{
			Items = new List<RecentlyItem>();
		}

		[JsonProperty("items")]
		public IList<RecentlyItem> Items { get; set; }
	}
}