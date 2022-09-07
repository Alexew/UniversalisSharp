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
		public void GetItemHistoryAsync()
		{
			var item = client.Market.GetItemHistoryAsync(DataCenter, ItemId).Result;

			Assert.IsNotNull(item);
		}

		[TestMethod]
		public void GetItemsHistoryAsync()
		{
			var items = client.Market.GetItemsHistoryAsync(DataCenter, new int[] { ItemId, ItemId2 }).Result;
			var oneItem = client.Market.GetItemsHistoryAsync(DataCenter, new int[] { ItemId }).Result;

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

		[TestMethod]
		public void GetMostRecentlyUpdatedItemsAsync()
		{
			var items = client.Market.GetMostRecentlyUpdatedItemsAsync(dcName: DataCenter).Result;
			var oneItem = client.Market.GetMostRecentlyUpdatedItemsAsync(dcName: DataCenter, entries: 1).Result;

			Assert.IsTrue(items.Count > 0);
			Assert.IsTrue(oneItem.Count == 1);
		}

		[TestMethod]
		public void GetRecentlyUpdatedItemsAsync()
		{
			var items = client.Market.GetRecentlyUpdatedItemsAsync().Result;

			Assert.IsTrue(items.Count > 0);
		}

		[TestMethod]
		public void GetTaxRates()
		{
			var taxRates = client.Market.GetTaxRates(World).Result;

			Assert.IsTrue(taxRates.Count > 0);
		}
	}
}