using System;
using Microsoft.Extensions.Logging;
using CompanYoungAPI.Model;
using CommonServiceLocator;
using SolrNet;
using SolrNet.Impl;
using System.Collections;
using SolrNet.Commands.Parameters;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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

		public DataEntry GetById(string id)
		{
			var result = solr.Query(new SolrQuery($"id:{id}"));
			return result.First();
		}

		private IEnumerable<string[]> GetUniquePaths()
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

