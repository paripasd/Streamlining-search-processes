using CompanYoungAPI.Model;
using CommonServiceLocator;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace CompanYoungAPI.DataAccess
{
	public class ReadDataAccess
    {
		ISolrOperations<DataEntry> solr;

        public ReadDataAccess()
		{
			solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
		}

		// get all data in the database in a specific order
		public IEnumerable<DataEntry> GetAll()
		{
			var options = new QueryOptions
            {
                // set the sort order
                OrderBy = new[] { new SortOrder("id", Order.DESC) }
            };

			SolrQueryResults<DataEntry> result = new();
			try
			{
				// "*:*" refers to the Solr query language, it means get any field and any values
                result = solr.Query(new SolrQuery("*:*"), options);
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
            
			return result;
		}

		// get all units based on the path field values we provide in the parameter
		public IEnumerable<DataEntry> GetAllByPath(string[] path)
		{
			List<SolrQuery> queryParams = new List<SolrQuery>();
			foreach(string s in path)
			{
				// building the query to search for each part of the path
				queryParams.Add(new SolrQuery("path:\"" + s + "\""));
			}

            var options = new QueryOptions
            {
                // set the sort order
                OrderBy = new[] { new SortOrder("id", Order.DESC) }
            };

            SolrQueryResults<DataEntry> result = new();
            try
			{
				// we add our criteria to the query and use the "AND" operator
                result = solr.Query(new SolrMultipleCriteriaQuery(queryParams, "AND"), options);
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
            
			return result;
		}

		// get all questions for a specific path, this is used in the searchfield dropdown 
        public string[] GetAllQuestionByPathForSuggestion(string[] path)
        {
			var result = GetAllByPath(path);
            string[] questions = result.Select(x => x.Question).ToArray();
            HashSet<string> questionSet = new HashSet<string>(questions);
            return questionSet.ToArray();
        }

		// get unit by id
        public DataEntry GetById(string id)
		{
            SolrQueryResults<DataEntry> result = new();
            try
			{
                result = solr.Query(new SolrQuery($"id:{id}"));
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			
			return result.First();
		}

		public List<DataEntryWithHighlight> GetBySearch(string searchText, string[] path)
		{
			List<SolrQuery> textParams = new List<SolrQuery>();
			if (searchText != "null")
			{
                // we are doing the search in the question, answer, comment field if we have a valid search phrase
                textParams.Add(new SolrQuery($"question:\"{searchText}\""));
				textParams.Add(new SolrQuery($"answer:\"{searchText}\""));
				textParams.Add(new SolrQuery($"comment:\"{searchText}\""));
			}
			else
			{
				// if we have no search phrase we return everything
				textParams.Add(new SolrQuery("*:*"));
			}

			List<ISolrQuery> queryParams = new List<ISolrQuery>();
			queryParams.Add(new SolrMultipleCriteriaQuery(textParams, "OR"));

            // enable and customise highlighting for search
            HighlightingParameters highlightParams = new HighlightingParameters();
			highlightParams.Fields = new[] { "answer" }; // highlight only in answer field
            highlightParams.BeforeTerm = "<b><span style=\"color: #f28033\">"; // how we want to showcase the highlight (start)
            highlightParams.AfterTerm = "</span></b>";// how we want to showcase the highlight (end)
            highlightParams.UsePhraseHighlighter = true; // highlight words next to each other
			highlightParams.Fragsize = 0; // (0) idicates that the whole field value should be used, no fregmentation
			highlightParams.Snippets = 1000000; // maximum number of highlighted snippets to return


            var options = new QueryOptions
			{
                Highlight = highlightParams,
                
                OrderBy = new[] { new SortOrder("id", Order.DESC) }

            };

			SolrQueryResults<DataEntry> solrResult = new();

			try
			{
				// sending the query with the above defined options and parameters
                solrResult = solr.Query(new SolrMultipleCriteriaQuery(queryParams), options);
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			List<DataEntryWithHighlight> pathFilteredData = new List<DataEntryWithHighlight>();
			// filtering for path and formatting for easier usage in the UI
			// this part may be reconsidered as Solr might be able to handle path filtering within this query!!!
			foreach (var r in solrResult)
			{
				if (path.Length > 1)
				{
					if (r.Path.SequenceEqual(path))
					{
                        DataEntryWithHighlight de = new DataEntryWithHighlight();
                        de.Answer = r.Answer;
                        de.Question = r.Question;
                        de.Comment = r.Comment;
                        de.Id = r.Id;
                        de.Tags = r.Tags;
                        de.Path = r.Path;
                        de.ModificationDate = r.ModificationDate;
                        de.Expiry = r.Expiry;
                        foreach (var highlight in solrResult.Highlights)
                        {
                            if (highlight.Key.Equals(r.Id))
                            {
                                de.Snippet = highlight.Value;

                            }
                        }
                        pathFilteredData.Add(de);
					}
				}
				else
				{
					if (r.Path.Any(element => path.Contains(element)))
					{
                        DataEntryWithHighlight de = new DataEntryWithHighlight();
                        de.Answer = r.Answer;
                        de.Question = r.Question;
                        de.Comment = r.Comment;
                        de.Id = r.Id;
                        de.Tags = r.Tags;
                        de.Path = r.Path;
                        de.ModificationDate = r.ModificationDate;
                        de.Expiry = r.Expiry;
                        foreach (var highlight in solrResult.Highlights)
                        {
                            if (highlight.Key.Equals(r.Id))
                            {
                                de.Snippet = highlight.Value;

                            }
                        }
                        pathFilteredData.Add(de);
                    }
				}
			}
            return pathFilteredData;
        }

		// get unique paths ex: for tree, dropdown
        public IEnumerable<string[]> GetUniquePaths()
		{
			var queryOptions = new QueryOptions
			{
				Fields = new[] { "path" },
				Rows = int.MaxValue
			};

            SolrQueryResults<DataEntry> result = new();
            try
			{
                result = solr.Query(new SolrQuery("*:*"), queryOptions);
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			
			// its magic and it works to get unique paths
			var uniquePaths = result.Select(r => r.Path)
				.GroupBy(pathArray => string.Join("|", pathArray))
				.Select(group => group.First())
				.ToList();
			return uniquePaths;
		}

		// get institute names from path, first element of path is always institute
		public IEnumerable<string> GetInstitutes()
		{
			IEnumerable<string[]> paths = GetUniquePaths();
			var institutes = paths.Select(p => p[0]).Distinct();
			return institutes;
		}

        // get subpath names from path, everything except the first element of path is subpath
        public IEnumerable<string[]> GetInstituteSubPaths(string institute)
		{
			IEnumerable<string[]> paths = GetUniquePaths();
			var subpaths = paths.Where(p => p[0] == institute).Select(p => p[1..]);
			return subpaths;
		}

		// this class is here because we only use this in the method below so coupling it here is the best choice
		// we need this because we are showcasing data in a tree format in the UI 
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
				// if we find the child we return it, if we don't than we create a new in the tree
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

		// tree structure logic for building
		// get all unique paths, assign them as root nodes, check all root nodes for child nodes
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

