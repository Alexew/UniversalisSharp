using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniversalisSharp.Test.EndpointTests
{
	[TestClass]
	public class MarketTests : BaseTests
	{
		[TestMethod]
		public void GetItemsDataAsync()
		{
			var items = client.Market.GetItemsDataAsync(DataCenter, new int[] { ItemId, ItemId2 }).Result;

			Assert.IsTrue(items.Count > 0);
		}
	}
}
