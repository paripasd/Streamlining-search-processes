using CommonServiceLocator;
using CompanYoungAPI.Model;
using SolrNet;

namespace CompanYoungAPI.DataAccess
{
    public class UpdateDataAccess
    {
        ISolrOperations<DataEntry> Solr;

        public UpdateDataAccess()
        {
            Solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
        }

        public void UpdateInstance(DataEntry data) 
        {
            Solr.Add(data);
            Solr.Commit();
        }

        public void UpdateExpiredTagByDate()
		{
            var query = !new SolrQueryByField("tags", "Expired") & new SolrQueryByRange<DateTime>("expiry", DateTime.MinValue, DateTime.UtcNow);

            var results = Solr.Query(query);

			var updatedDocs = new List<DataEntry>();
			foreach (var doc in results)
			{
                doc.Tags = doc.Tags.Concat(new string[] {"Expired"}).ToArray(); //adds the expired tag
                doc.Tags = doc.Tags.Where(x => x != "Expires soon").ToArray(); //removes the expires soon tag
				updatedDocs.Add(doc);
			}
			Solr.AddRange(updatedDocs);
			Solr.Commit();
		}

        public void UpdateExpiredTagPlus()
        {
            var query = new SolrQueryByField("tags", "Expired") & new SolrQueryByRange<DateTime>("expiry", DateTime.UtcNow, DateTime.MaxValue) || new SolrQueryByRange<DateTime>("expiry", DateTime.UtcNow, DateTime.UtcNow.AddDays(14));

            var results = Solr.Query(query);

            var updatedDocs = new List<DataEntry>();
            foreach (var doc in results)
            {
                doc.Tags = doc.Tags.Where(x => x != "Expired").ToArray(); //removes the expired tag
                updatedDocs.Add(doc);
            }
            Solr.AddRange(updatedDocs);
            Solr.Commit();
        }

        public void UpdateExpiresSoonTagPlus()
        {
            var query = new SolrQueryByField("tags", "Expires soon") & new SolrQueryByRange<DateTime>("expiry", DateTime.UtcNow.AddDays(14), DateTime.MaxValue);

            var results = Solr.Query(query);

            var updatedDocs = new List<DataEntry>();
            foreach (var doc in results)
            {
                doc.Tags = doc.Tags.Where(x => x != "Expires soon").ToArray(); //removes the expires soon tag
                updatedDocs.Add(doc);
            }
            Solr.AddRange(updatedDocs);
            Solr.Commit();
        }

        public void UpdateExpiressoonTagByDate()
		{
			var query = /*!new SolrQueryByField("tags", "Expires soon") & */!new SolrQueryByField("tags", "Expired") & new SolrQueryByRange<DateTime>("expiry", DateTime.MinValue, DateTime.UtcNow.AddDays(14));
			var results = Solr.Query(query);

			var updatedDocs = new List<DataEntry>();
			foreach (var doc in results)
			{
				if(!doc.Tags.Contains("Expires soon"))
				{
					doc.Tags = doc.Tags.Concat(new string[] { "Expires soon" }).ToArray(); //adds the expires soon tag
                    updatedDocs.Add(doc);
				}
			}
			Solr.AddRange(updatedDocs);
			Solr.Commit();
		}
	}
}
