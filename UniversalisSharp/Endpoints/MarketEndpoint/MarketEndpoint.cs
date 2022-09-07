using Newtonsoft.Json;
using UniversalisSharp.Endpoints.MarketEndpoint.Models;
using UniversalisSharp.Http;

namespace UniversalisSharp.Endpoints.MarketEndpoint
{
	public class MarketEndpoint : IMarketEndpoint
	{
		private const string DataUrl = "/api/v2/{0}/{1}";
		private const string HistoryUrl = "/api/v2/history/{0}/{1}";
		private const string LeastRecentlyUpdatedUrl = "/api/v2/extra/stats/least-recently-updated";
		private const string MostRecentlyUpdatedUrl = "/api/v2/extra/stats/most-recently-updated";
		private const string RecentlyUpdatedUrl = "/api/v2/extra/stats/recently-updated";
		private const string TaxRatesUrl = "/api/v2/tax-rates";

		private readonly IRequester _requester;

		public MarketEndpoint(IRequester requester)
		{
			_requester = requester;
		}

		public async Task<Item?> GetItemDataAsync(string worldDcRegion, int itemId,
			int? listings = null, int? entries = null, bool? noGst = null, bool? hq = null)
		{
			var parameters = CreateDataRequestParametersList(listings, entries, noGst, hq);
			var json = await _requester.SendRequestAsync(string.Format(DataUrl, worldDcRegion, itemId), parameters);

			if (json == null)
				return null;

			return JsonConvert.DeserializeObject<Item>(json);
		}

		public async Task<IList<Item>> GetItemsDataAsync(string worldDcRegion, int[] itemIds,
			int? listings = null, int? entries = null, bool? noGst = null, bool? hq = null)
		{
			var parameters = CreateDataRequestParametersList(listings, entries, noGst, hq);
			var json = await _requester.SendRequestAsync(string.Format(DataUrl, worldDcRegion, string.Join(',', itemIds)), parameters);
			if (json == null)
				return new List<Item>();

			// JSON has a different structure if there is only one identifier.
			if (itemIds.Length == 1)
			{
				var item = JsonConvert.DeserializeObject<Item>(json);
				if (item == null)
					return new List<Item>();
				else
					return new List<Item> { item };
			}

			var board = JsonConvert.DeserializeObject<BoardResponse>(json);
			if (board == null)
				return new List<Item>();

			return board.Items.Select(x => x.Value).ToList();
		}

		public async Task<HistoryItem?> GetItemHistoryAsync(string worldDcRegion, int itemId, int? entriesToReturn = null)
		{
			var parameters = CreateHistoryRequestParametersList(entriesToReturn);
			var json = await _requester.SendRequestAsync(string.Format(DataUrl, worldDcRegion, itemId), parameters);

			if (json == null)
				return null;

			return JsonConvert.DeserializeObject<HistoryItem>(json);
		}

		public async Task<IList<HistoryItem>> GetItemsHistoryAsync(string worldDcRegion, int[] itemIds, int? entriesToReturn = null)
		{
			var parameters = CreateHistoryRequestParametersList(entriesToReturn);
			var json = await _requester.SendRequestAsync(string.Format(HistoryUrl, worldDcRegion, string.Join(',', itemIds)), parameters);
			if (json == null)
				return new List<HistoryItem>();

			// JSON has a different structure if there is only one identifier.
			if (itemIds.Length == 1)
			{
				var item = JsonConvert.DeserializeObject<HistoryItem>(json);
				if (item == null)
					return new List<HistoryItem>();
				else
					return new List<HistoryItem> { item };
			}

			var history = JsonConvert.DeserializeObject<HistoryResponse>(json);
			if (history == null)
				return new List<HistoryItem>();

			return history.Items.Select(x => x.Value).ToList();
		}

		public async Task<IList<RecentlyItem>> GetLeastRecentlyUpdatedItemsAsync(string? world = null, string? dcName = null, int? entries = null)
		{
			var parameters = CreateRecentlyUpdatedRequestParametersList(world, dcName, entries);
			var json = await _requester.SendRequestAsync(LeastRecentlyUpdatedUrl, parameters);
			if (json == null)
				return new List<RecentlyItem>();

			var list = JsonConvert.DeserializeObject<RecentlyUpdatedResponse>(json);
			if (list == null)
				return new List<RecentlyItem>();

			return list.Items;
		}

		public async Task<IList<RecentlyItem>> GetMostRecentlyUpdatedItemsAsync(string? world = null, string? dcName = null, int? entries = null)
		{
			var parameters = CreateRecentlyUpdatedRequestParametersList(world, dcName, entries);
			var json = await _requester.SendRequestAsync(MostRecentlyUpdatedUrl, parameters);
			if (json == null)
				return new List<RecentlyItem>();

			var list = JsonConvert.DeserializeObject<RecentlyUpdatedResponse>(json);
			if (list == null)
				return new List<RecentlyItem>();

			return list.Items;
		}

		public async Task<IList<int>> GetRecentlyUpdatedItemsAsync()
		{
			var json = await _requester.SendRequestAsync(RecentlyUpdatedUrl);
			if (json == null)
				return new List<int>();

			var list = JsonConvert.DeserializeObject<SimpleRecentlyUpdatedResponse>(json);
			if (list == null)
				return new List<int>();

			return list.Items;
		}

		public async Task<IDictionary<string, int>> GetTaxRates(string world)
		{
			var parametes = CreateTaxRatesRequestParametersList(world);
			var json = await _requester.SendRequestAsync(TaxRatesUrl, parametes);
			if (json == null)
				return new Dictionary<string, int>();

			var taxRates = JsonConvert.DeserializeObject<IDictionary<string, int>>(json);
			if (taxRates == null)
				return new Dictionary<string, int>();

			return taxRates;
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

		private IDictionary<string, string> CreateHistoryRequestParametersList(int? entriesToReturn)
		{
			var parameters = new Dictionary<string, string>();

			if (entriesToReturn.HasValue)
				parameters.Add("entriesToReturn", entriesToReturn.Value.ToString());

			return parameters;
		}

		private IDictionary<string, string> CreateRecentlyUpdatedRequestParametersList(string? world, string? dcName, int? entries)
		{
			var parameters = new Dictionary<string, string>();

			if (world != null)
				parameters.Add("world", world);

			if (dcName != null)
				parameters.Add("dcName", dcName);

			if (entries.HasValue)
				parameters.Add("entries", entries.Value.ToString());

			return parameters;
		}

		private IDictionary<string, string> CreateTaxRatesRequestParametersList(string world)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "world", world }
			};

			return parameters;
		}
	}
}