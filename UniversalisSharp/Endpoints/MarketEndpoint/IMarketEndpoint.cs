namespace UniversalisSharp.Endpoints.MarketEndpoint
{
	public interface IMarketEndpoint
	{
		Task<IList<Item>> GetItemsDataAsync(string worldDcRegion, int[] itemIds,
			int? listings = null, int? entries = null, bool? noGst = null, bool? hq = null);
	}
}