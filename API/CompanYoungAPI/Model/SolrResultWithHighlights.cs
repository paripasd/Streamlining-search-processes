using SolrNet.Attributes;
using SolrNet.Impl;

namespace CompanYoungAPI.Model
{
    public class SolrResultWithHighlights
    {
        public DataEntry Data { get; set; }

        public KeyValuePair<string,HighlightedSnippets> Highlights { get; set; }
        public SolrResultWithHighlights()
        {

        }
    }
}
