using SolrNet.Attributes;
using SolrNet.Impl;

namespace CompanYoungAPI.Model
{
    public class DataEntryWithHighlight : DataEntry
    {
		public HighlightedSnippets Snippet { get; set; }

	}
}
