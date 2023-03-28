using System;
using Microsoft.Extensions.Logging;
using CompanYoungAPI.Model;
using CommonServiceLocator;
using SolrNet;
using SolrNet.Impl;
using System.Collections;
using SolrNet.Commands.Parameters;
using System.Linq;

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

		public string[] GetUniquePaths()
		{
			var queryOptions = new QueryOptions
			{
				Facet = new FacetParameters
				{
					Queries = new ISolrFacetQuery[] { new SolrFacetFieldQuery("path") },
					Limit = int.MaxValue
				},
				Rows = 0
			};
			var result = solr.Query(new SolrQuery("*:*"), queryOptions);
			var paths = result.FacetFields["path"].Select(x => x.Key).ToArray();
			return paths;
		}
	}
	
}

