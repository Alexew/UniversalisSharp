using Newtonsoft.Json;
using UniversalisSharp.Endpoints.InfoEndpoint.Models;
using UniversalisSharp.Http;

namespace UniversalisSharp.Endpoints.InfoEndpoint
{
    public class InfoEndpoint : IInfoEndpoint
    {
        private const string DataCentersUrl = "/api/v2/data-centers";
        private const string WorldsUrl = "/api/v2/worlds";
        private const string MarketableUrl = "/api/v2/marketable";
        private const string UploaderUploadCountsUrl = "/api/v2/extra/stats/uploader-upload-counts";
        private const string WorldUploadCountsUrl = "/api/v2/extra/stats/world-upload-counts";
        private const string UploadHistoryUrl = "/api/v2/extra/stats/upload-history";

        private readonly IRequester _requester;

        public InfoEndpoint(IRequester requester)
        {
            _requester = requester;
        }

        public async Task<IList<DataCenter>> GetDataCentersAsync()
        {
            var json = await _requester.SendRequestAsync(DataCentersUrl);
            if (json == null)
                return new List<DataCenter>();

            var list = JsonConvert.DeserializeObject<IList<DataCenter>>(json);
            if (list == null)
                return new List<DataCenter>();

            return list;
        }

        public async Task<IList<World>> GetWorldsAsync()
        {
            var json = await _requester.SendRequestAsync(WorldsUrl);
            if (json == null)
                return new List<World>();

            var list = JsonConvert.DeserializeObject<IList<World>>(json);
            if (list == null)
                return new List<World>();

            return list;
        }

        public async Task<IList<int>> GetMarketableAsync()
        {
            var json = await _requester.SendRequestAsync(MarketableUrl);
            if (json == null)
                return new List<int>();

            var list = JsonConvert.DeserializeObject<IList<int>>(json);
            if (list == null)
                return new List<int>();

            return list;
        }

        public async Task<IList<UploaderUploadCount>> GetUploaderUploadCountsAsync()
        {
            var json = await _requester.SendRequestAsync(UploaderUploadCountsUrl);
            if (json == null)
                return new List<UploaderUploadCount>();

            var list = JsonConvert.DeserializeObject<IList<UploaderUploadCount>>(json);
            if (list == null)
                return new List<UploaderUploadCount>();

            return list;
        }

        public async Task<IDictionary<string, WorldUploadCount>> GetWorldUploadCountsAsync()
        {
            var json = await _requester.SendRequestAsync(WorldUploadCountsUrl);
            if (json == null)
                return new Dictionary<string, WorldUploadCount>();

            var list = JsonConvert.DeserializeObject<IDictionary<string, WorldUploadCount>>(json);
            if (list == null)
                return new Dictionary<string, WorldUploadCount>();

            return list;
        }

        public async Task<UploadHistory?> GetUploadHistoryAsync()
        {
            var json = await _requester.SendRequestAsync(UploadHistoryUrl);
            if (json == null)
                return null;

            var list = JsonConvert.DeserializeObject<UploadHistory>(json);
            if (list == null)
                return null;

            return list;
        }
    }
}