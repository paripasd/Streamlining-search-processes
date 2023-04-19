using SolrNet.Attributes;
using SolrNet.Impl;

namespace CompanYoungAPI.Model
{
    public class DataEntryWithHighlight
    {
        public string Question { get; set; }

        public string Answer { get; set; }

        public string Comment { get; set; }

        public string Id { get; set; }

 
        public string[] Tags { get; set; }


        public string[] Path { get; set; }


        public DateTime ModificationDate { get; set; }

        public HighlightedSnippets Snippet { get; set; }

        public DateTime Expiry { get; set; }

    }
}
