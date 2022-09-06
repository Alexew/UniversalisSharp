using UniversalisSharp.Endpoints.MarketEndpoint.Models;

namespace UniversalisSharp.Endpoints.MarketEndpoint
{
	public interface IMarketEndpoint
	{
		Task<Item?> GetItemDataAsync(string worldDcRegion, int itemId,
			int? listings = null, int? entries = null, bool? noGst = null, bool? hq = null);

		Task<IList<Item>> GetItemsDataAsync(string worldDcRegion, int[] itemIds,
			int? listings = null, int? entries = null, bool? noGst = null, bool? hq = null);

		Task<IList<RecentlyItem>> GetLeastRecentlyUpdatedItemsAsync(string? world = null, string? dcName = null, int? entries = null);
	}
}