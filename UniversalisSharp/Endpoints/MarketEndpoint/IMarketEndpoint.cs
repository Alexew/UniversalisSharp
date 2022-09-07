using UniversalisSharp.Endpoints.MarketEndpoint.Models;

namespace UniversalisSharp.Endpoints.MarketEndpoint
{
	public interface IMarketEndpoint
	{
		Task<Item?> GetItemDataAsync(string worldDcRegion, int itemId,
			int? listings = null, int? entries = null, bool? noGst = null, bool? hq = null);

		Task<IList<Item>> GetItemsDataAsync(string worldDcRegion, int[] itemIds,
			int? listings = null, int? entries = null, bool? noGst = null, bool? hq = null);

		Task<HistoryItem?> GetItemHistoryAsync(string worldDcRegion, int itemId, int? entriesToReturn = null);

		Task<IList<HistoryItem>> GetItemsHistoryAsync(string worldDcRegion, int[] itemIds, int? entriesToReturn = null);

		Task<IList<RecentlyItem>> GetLeastRecentlyUpdatedItemsAsync(string? world = null, string? dcName = null, int? entries = null);

		Task<IList<RecentlyItem>> GetMostRecentlyUpdatedItemsAsync(string? world = null, string? dcName = null, int? entries = null);

		Task<IList<int>> GetRecentlyUpdatedItemsAsync();

		Task<IDictionary<string, int>> GetTaxRates(string world);
	}
}