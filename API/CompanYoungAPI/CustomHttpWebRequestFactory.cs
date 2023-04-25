using HttpWebAdapters;
using HttpWebAdapters.Adapters;
using SolrNet.Utils;
using System.Net;

public class CustomHttpWebRequestFactory : IHttpWebRequestFactory
{
	public string jwtToken { get; set; }

	public CustomHttpWebRequestFactory(string jwtToken)
	{
		this.jwtToken = jwtToken;
	}

	public IHttpWebRequest Create(Uri url)
	{
		var request = (HttpWebRequest)WebRequest.Create(url);
		if (!string.IsNullOrEmpty(jwtToken))
		{
			request.Headers.Add("Authorization", $"Bearer {jwtToken}");
		}
		return new HttpWebRequestAdapter(request);
	}
}
