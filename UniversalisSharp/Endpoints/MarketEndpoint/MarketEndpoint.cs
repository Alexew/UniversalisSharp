using Newtonsoft.Json;
using UniversalisSharp.Http;

namespace UniversalisSharp.Endpoints.MarketEndpoint
{
	public class MarketEndpoint : IMarketEndpoint
	{
		private const string DataUrl = "/api/v2/{0}/{1}";

		private readonly IRequester _requester;

		public MarketEndpoint(IRequester requester)
		{
			_requester = requester;
		}

		public async Task<IList<Item>> GetItemsDataAsync(string worldDcRegion, int[] itemIds,
			int? listings = null, int? entries = null, bool? noGst = null, bool? hq = null)
		{
			var parameters = CreateDataRequestParametersList(listings, entries, noGst, hq);
			var json = await _requester.SendRequestAsync(string.Format(DataUrl, worldDcRegion, string.Join(',', itemIds)), parameters);
			if (json == null)
				return new List<Item>();

			var board = JsonConvert.DeserializeObject<BoardResponse>(json);
			if (board == null)
				return new List<Item>();

			return board.Items.Select(x => x.Value).ToList();
		}

		private IDictionary<string, string> CreateDataRequestParametersList(int? listings, int? entries, bool? noGst, bool? hq)
		{
			var parameters = new Dictionary<string, string>();

			if (listings.HasValue)
				parameters.Add("listings", listings.Value.ToString());

			if (entries.HasValue)
				parameters.Add("entries", entries.Value.ToString());

			if (noGst.HasValue)
				parameters.Add("noGst", noGst.Value.ToString());

			if (hq.HasValue)
				parameters.Add("hq", hq.Value.ToString());

			return parameters;
		}
	}
}