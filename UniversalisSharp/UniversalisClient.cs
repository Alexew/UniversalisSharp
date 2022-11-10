using UniversalisSharp.Endpoints.InfoEndpoint;
using UniversalisSharp.Endpoints.MarketEndpoint;
using UniversalisSharp.Http;

namespace UniversalisSharp
{
	public class UniversalisClient
	{
		public UniversalisClient()
		{
			var requester = new Requester();

			Info = new InfoEndpoint(requester);
			Market = new MarketEndpoint(requester);
		}

		public IInfoEndpoint Info { get; }
		public IMarketEndpoint Market { get; }
	}
}