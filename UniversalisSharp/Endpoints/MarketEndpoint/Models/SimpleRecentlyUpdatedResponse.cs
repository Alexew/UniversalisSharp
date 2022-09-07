using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.MarketEndpoint.Models
{
	public class SimpleRecentlyUpdatedResponse
	{
		public SimpleRecentlyUpdatedResponse()
		{
			Items = new List<int>();
		}

		[JsonProperty("items")]
		public IList<int> Items { get; set; }
	}
}
