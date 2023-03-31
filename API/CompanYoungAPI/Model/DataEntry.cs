using System;
using SolrNet.Attributes;
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
		[SolrField("path")]
		public string[] Path { get; set; }
		/*[SolrField("_version_")]
		public double Version { get; set; }*/
        //public DateTime Expiry { get; set; } to be added later
        //public string ModifiedBy { get; set; }


        public DataEntry(string question, string answer, string comment, string id, string[] path)
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

