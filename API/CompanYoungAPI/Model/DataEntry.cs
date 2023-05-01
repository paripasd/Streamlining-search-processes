using System;
using SolrNet.Attributes;
using SolrNet.Impl;

namespace CompanYoungAPI.Model
{
	public class DataEntry
	{
		[SolrField("question")]
		public string Question { get; set; }
		[SolrField("answer")]
		public string Answer { get; set; }
		[SolrField("comment")]
		public string Comment { get; set; }
		[SolrField("id")]
		public string Id { get; set; }

        [SolrField("tags")]
        public string[] Tags { get; set; }

        [SolrField("path")]
        public string[] Path { get; set; }

        [SolrField("modification_date")]
        public DateTime ModificationDate { get; set; }

        //public ICollection<ICollection<string>> Snippets { get; set; }

        [SolrField("_version_")]
		public long Version { get; set; }

		[SolrField("expiry")]
        public DateTime Expiry { get; set; }
        //public string ModifiedBy { get; set; }


        public DataEntry(string question, string answer, string comment, string id, string[] path, string[] tags)
		{
			Question = question;
			Answer = answer;
			Comment = comment;
			Id = id;
			Path = path;
		}

        public DataEntry()
		{

		}
	}
}

