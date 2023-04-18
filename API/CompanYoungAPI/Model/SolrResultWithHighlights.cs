using SolrNet.Attributes;
using SolrNet.Impl;

namespace CompanYoungAPI.Model
{
    public class SolrResultWithHighlights
    {
        public List<DataEntry> Data { get; set; }

        public IDictionary<string,HighlightedSnippets> Highlights { get; set; }
        public SolrResultWithHighlights()
        {

        }
    }
}
