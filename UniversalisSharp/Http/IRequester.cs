using RestSharp;

namespace UniversalisSharp.Http
{
	public interface IRequester
	{
		Task<string?> SendRequestAsync(string url, IDictionary<string, string> parameters, Method method = Method.Get);
	}
}