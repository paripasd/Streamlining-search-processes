using System;
using Microsoft.Extensions.Logging;
using CompanYoungAPI.Model;
using CommonServiceLocator;
using SolrNet;
using SolrNet.Impl;
using System.Collections;
using SolrNet.Commands.Parameters;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NuGet.Protocol;
using SolrNet.Schema;
using System.Linq;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.Exceptions;
using SolrNet.Impl;

using System;

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
            var options = new QueryOptions
            {
                // set the sort order
                OrderBy = new[] { new SortOrder("id", Order.DESC) }
            };
            var result = solr.Query(new SolrQuery("*:*"),options);
			return result;
		}

		public IEnumerable<DataEntry> GetAllByPath(string[] path)
		{
			List<SolrQuery> queryParams = new List<SolrQuery>();
			foreach(string s in path)
			{
				queryParams.Add(new SolrQuery("path:\"" + s + "\""));
			}
            var options = new QueryOptions
            {
                // set the sort order
                OrderBy = new[] { new SortOrder("id", Order.DESC) }
            };
            var result = solr.Query(new SolrMultipleCriteriaQuery(queryParams, "AND"),options);
			return result;
		}

        public string[] GetAllQuestionByPathForSuggestion(string[] path)
        {
			var result = GetAllByPath(path);
            string[] questions = result.Select(x => x.Question).ToArray();
            HashSet<string> questionSet = new HashSet<string>(questions);
            return questionSet.ToArray();
        }

        public DataEntry GetById(string id)
		{
			var result = solr.Query(new SolrQuery($"id:{id}"));
			return result.First();
		}

        public IEnumerable<DataEntry> GetBySearch(string searchText, string[] path)
        {
            List<SolrQuery> textParams = new List<SolrQuery>();
            if (searchText != "null")
            {
                textParams.Add(new SolrQuery($"question:{searchText}"));
                textParams.Add(new SolrQuery($"answer:{searchText}"));
                textParams.Add(new SolrQuery($"comment:{searchText}"));
            }
            else
            {
                textParams.Add(new SolrQuery("*:*"));
            }
            List<SolrQuery> pathParams = new List<SolrQuery>();
            foreach (string s in path)
            {
                pathParams.Add(new SolrQuery($"path:\"{s}\""));
            }
            List<ISolrQuery> queryParams = new List<ISolrQuery>();
            queryParams.Add(new SolrMultipleCriteriaQuery(textParams, "OR"));
            if (path.Length != 0)
            {
                queryParams.Add(new SolrMultipleCriteriaQuery(pathParams, "AND"));
            }
            var options = new QueryOptions
            {
                // set the sort order
                OrderBy = new[] { new SortOrder("id", Order.DESC) },
                // set highlight
                Highlight = new HighlightingParameters
                {
                    Fields = new[] { "answer" },
                }
			};
            var solrResult = solr.Query(new SolrMultipleCriteriaQuery(queryParams, "AND"), options);

            return solrResult;
        }

        public IEnumerable<string[]> GetUniquePaths()
		{
			var queryOptions = new QueryOptions
			{
				Fields = new[] { "path" },
				Rows = int.MaxValue
			};
			var result = solr.Query(new SolrQuery("*:*"), queryOptions);
			var uniquePaths = result.Select(r => r.Path)
				.GroupBy(pathArray => string.Join("|", pathArray))
				.Select(group => group.First())
				.ToList();
			return uniquePaths;
		}

		public IEnumerable<string> GetInstitutes()
		{
			IEnumerable<string[]> paths = GetUniquePaths();
			var institutes = paths.Select(p => p[0]).Distinct();
			return institutes;
		}

		public IEnumerable<string[]> GetInstituteSubPaths(string institute)
		{
			IEnumerable<string[]> paths = GetUniquePaths();
			var subpaths = paths.Where(p => p[0] == institute).Select(p => p[1..]);
			return subpaths;
		}

		public class Node
		{
			public string label { get; set; }
			public List<string> path { get; set; }
			public List<Node> nodes { get; set; }

			public Node(string label)
			{
				this.label = label;
				path = new();
				nodes = new List<Node>();
			}

			public Node FindOrCreateChild(string label)
			{
				Node child = nodes.Find(x => x.label == label);
				if (child == null)
				{
					child = new Node(label);
					path.ForEach(p => child.path.Add(p));
					child.path.Add(child.label);
					nodes.Add(child);
				}
				return child;
			}
		}

		public IEnumerable<Node> GetTreeStructure()
		{
			IEnumerable<string[]> paths = GetUniquePaths();
			Node rootNode = new Node("root");

			foreach (string[] path in paths)
			{
				Node currentNode = rootNode;
				foreach (string nodeName in path)
				{
					currentNode = currentNode.FindOrCreateChild(nodeName);
				}
			}
			return rootNode.nodes;

		}
	}
	
}

