using System;
using Microsoft.Extensions.Logging;
using CompanYoungAPI.Model;
using CommonServiceLocator;
using SolrNet;
using SolrNet.Impl;
using System.Collections;

namespace CompanYoungAPI.DataAccess
{
	public class ReadDataAccess
	{
		ISolrOperations<DataEntry> solr;

		public ReadDataAccess()
		{
			solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
		}

		public IEnumerable<DataEntry> GetAll()
		{
			var result = solr.Query(new SolrQuery("*:*"));
			return result;
		}

		public IEnumerable<DataEntry> GetAllByPath(string[] path)
		{
			List<SolrQuery> queryParams = new List<SolrQuery>();
			foreach(string s in path)
			{
				queryParams.Add(new SolrQuery("path:\"" + s + "\""));
			}
			var result = solr.Query(new SolrMultipleCriteriaQuery(queryParams, "AND"));
			return result;
		}
	}
	
}

