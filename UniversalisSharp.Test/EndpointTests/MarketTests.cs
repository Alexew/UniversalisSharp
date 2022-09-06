using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniversalisSharp.Test.EndpointTests
{
	[TestClass]
	public class MarketTests : BaseTests
	{
		[TestMethod]
		public void GetItemDataAsync()
		{
			var item = client.Market.GetItemDataAsync(DataCenter, ItemId).Result;

			Assert.IsNotNull(item);
		}

		[TestMethod]
		public void GetItemsDataAsync()
		{
			var items = client.Market.GetItemsDataAsync(DataCenter, new int[] { ItemId, ItemId2 }).Result;
			var oneItem = client.Market.GetItemsDataAsync(DataCenter, new int[] { ItemId }).Result;

			Assert.IsTrue(items.Count > 0);
			Assert.IsTrue(oneItem.Count == 1);
		}

		[TestMethod]
		public void GetLeastRecentlyUpdatedItemsAsync()
		{
			var items = client.Market.GetLeastRecentlyUpdatedItemsAsync(dcName: DataCenter).Result;
			var oneItem = client.Market.GetLeastRecentlyUpdatedItemsAsync(dcName: DataCenter, entries: 1).Result;

			Assert.IsTrue(items.Count > 0);
			Assert.IsTrue(oneItem.Count == 1);
		}
	}
}