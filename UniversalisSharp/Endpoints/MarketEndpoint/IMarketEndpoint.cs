namespace UniversalisSharp.Endpoints.MarketEndpoint
{
	public interface IMarketEndpoint
	{
		Task<IList<Item>> GetItemsData(string worldDcRegion, int[] itemIds,
			int? listings = null, int? entries = null, bool? noGst = null, bool? hq = null);
	}
}