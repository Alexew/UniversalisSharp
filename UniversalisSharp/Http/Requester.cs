using RestSharp;

namespace UniversalisSharp.Http
{
	public class Requester : IRequester
	{
		private const string Url = "https://universalis.app";

		private readonly RestClient _restClient;

		public Requester()
		{
			_restClient = new RestClient(Url);
		}

		public async Task<string?> SendRequestAsync(string url, IDictionary<string, string> parameters, Method method = Method.Get)
		{
			var request = PrepareRequest(url, parameters, method);
			var response = await _restClient.ExecuteAsync(request);

			return ProcessResponse(response);
		}

		private RestRequest PrepareRequest(string url, IDictionary<string, string> parameters, Method method = Method.Get)
		{
			var request = new RestRequest(url, method);

			foreach (var parameter in parameters)
			{
				request.AddQueryParameter(parameter.Key, parameter.Value);
			}

			return request;
		}

		private string? ProcessResponse(RestResponse response)
		{
			if (response == null)
				throw new UniversalisException("Universalis API returned null response.");
			else if (!response.IsSuccessful)
				throw new UniversalisException("Universalis API returned (" + response.StatusCode.ToString() + ") response.");

			return response.Content;
		}
	}
}