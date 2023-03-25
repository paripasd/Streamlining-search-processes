using System;
using Microsoft.Extensions.Logging;
using RestSharp;
using CompanYoungAPI.Model;
using CommonServiceLocator;
using SolrNet;

namespace CompanYoungAPI.DataAccess
{
	public class ReadDataAccess
	{

		public ReadDataAccess()
		{
		}

		/*public IEnumerable<DataEntry> GetAll()
		{
			var response = RestClient.Execute<IEnumerable<DataEntry>>(new RestRequest("http://localhost:8983/solr/testing/query?q=*:*"));
			return response.Data;
		}*/

		public DataEntry Get()
		{
			var solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
			var result = solr.Query(new SolrQuery("comment:KPI"));
			Console.WriteLine(result);
			return result.First();
		}
	}
	
}

