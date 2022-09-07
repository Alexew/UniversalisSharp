using Newtonsoft.Json;

namespace UniversalisSharp.Endpoints.MarketEndpoint.Models
{
	public class BoardResponse
	{
		public BoardResponse()
		{
			Items = new Dictionary<int, Item>();
		}

		[JsonProperty("items")]
		public Dictionary<int, Item> Items { get; set; }
	}
}