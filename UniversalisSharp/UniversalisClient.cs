using UniversalisSharp.Endpoints.MarketEndpoint;
using UniversalisSharp.Http;

namespace UniversalisSharp
{
	public class UniversalisClient
	{
		public UniversalisClient()
		{
			var requester = new Requester();

			Market = new MarketEndpoint(requester);
		}

		public IMarketEndpoint Market { get; }
	}
}