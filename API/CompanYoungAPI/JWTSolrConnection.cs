using System;
using SolrNet.Impl;

namespace CompanYoungAPI
{
	public class JWTSolrConnection : SolrConnection
	{
		private static CustomHttpWebRequestFactory customHttpWebRequestFactory;

		public JWTSolrConnection(string solrCoreUrl) : base(solrCoreUrl)
		{
			string InitialJwtToken = "";
			customHttpWebRequestFactory = new CustomHttpWebRequestFactory(InitialJwtToken);

			HttpWebRequestFactory = customHttpWebRequestFactory;
		}

		private static void UseToken(string token)
		{
			customHttpWebRequestFactory.jwtToken = token;
		}

		public static void ConfigureToken(HttpRequest request)
		{
			if (request == null) return;
			if (request.Headers.Authorization[0] == null) return;
			string jwtToken = request.Headers.Authorization[0].Substring("Bearer ".Length + 1);
			UseToken(jwtToken);
		}
	}
}

