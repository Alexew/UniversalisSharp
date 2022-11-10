using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniversalisSharp.Test.EndpointTests
{
    [TestClass]
    public class InfoTests : BaseTests
    {
        [TestMethod]
        public void GetDataCentersAsync()
        {
            var items = client.Info.GetDataCentersAsync().Result;

            Assert.IsTrue(items.Count > 0);
        }

        [TestMethod]
        public void GetWorldsAsync()
        {
            var items = client.Info.GetWorldsAsync().Result;

            Assert.IsTrue(items.Count > 0);
        }

        [TestMethod]
        public void GetMarketableAsync()
        {
            var items = client.Info.GetMarketableAsync().Result;

            Assert.IsTrue(items.Count > 0);
        }

        [TestMethod]
        public void GetUploaderUploadCountsAsync()
        {
            var items = client.Info.GetUploaderUploadCountsAsync().Result;

            Assert.IsTrue(items.Count > 0);
        }

        [TestMethod]
        public void GetWorldUploadCountsAsync()
        {
            var items = client.Info.GetWorldUploadCountsAsync().Result;

            Assert.IsTrue(items.Count > 0);
        }

        [TestMethod]
        public void GetUploadHistoryAsync()
        {
            var items = client.Info.GetUploadHistoryAsync().Result;

            Assert.IsNotNull(items);
            Assert.IsNotNull(items.UploadCountByDay);
            Assert.IsTrue(items.UploadCountByDay.Length > 0);
        }
    }
}