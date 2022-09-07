using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.MarketEndpoint.Models
{
	public class HistoryResponse
	{
		public HistoryResponse()
		{
			Items = new Dictionary<int, HistoryItem>();
		}

		[JsonProperty("items")]
		public Dictionary<int, HistoryItem> Items { get; set; }
	}
}