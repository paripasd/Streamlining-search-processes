using System;
using SolrNet.Impl;

namespace CompanYoungAPI
{
	public class JWTSolrConnection : SolrConnection
	{
		private static CustomHttpWebRequestFactory customHttpWebRequestFactory;

		public JWTSolrConnection(string solrCoreUrl) : base(solrCoreUrl)
		{
			string InitialJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ5b3VyLXVzZXJuYW1lIiwianRpIjoiNzNkZjk5MjctMzVlYy00NmM5LTgzNDgtMjBkMzVkZTUyYzJmIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6InlvdXItdXNlcm5hbWUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiIsImV4cCI6MTY4MjQ0OTU1MCwiaXNzIjoibG9jYWxob3N0IiwiYXVkIjoic29sciJ9.5tFad9rHbhNwbh-AB3lOgBDVrWR5qlDZQuscFfhLBf8";
			customHttpWebRequestFactory = new CustomHttpWebRequestFactory(InitialJwtToken);

			HttpWebRequestFactory = customHttpWebRequestFactory;
		}

		public static void UseToken(string token)
		{
			customHttpWebRequestFactory.jwtToken = token;
		}
	}
}

