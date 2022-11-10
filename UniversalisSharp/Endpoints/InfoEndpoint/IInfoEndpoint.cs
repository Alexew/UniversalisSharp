using UniversalisSharp.Endpoints.InfoEndpoint.Models;

namespace UniversalisSharp.Endpoints.InfoEndpoint
{
    public interface IInfoEndpoint
    {
        Task<IList<DataCenter>> GetDataCentersAsync();
        Task<IList<World>> GetWorldsAsync();

        Task<IList<int>> GetMarketableAsync();

        Task<IList<UploaderUploadCount>> GetUploaderUploadCountsAsync();
        Task<IDictionary<string, WorldUploadCount>> GetWorldUploadCountsAsync();
        Task<UploadHistory?> GetUploadHistoryAsync();
    }
}