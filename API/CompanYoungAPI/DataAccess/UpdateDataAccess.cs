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

        public bool UpdateInstance(DataEntry data) 
        {
            try
            {
                Solr.Add(data);
                Solr.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public void UpdateExpiredTagByDate()
		{
            // we need the units that doesn't have the Expired tag and the expiry field value is in the past to mark them
            var query = !new SolrQueryByField("tags", "Expired") & new SolrQueryByRange<DateTime>("expiry", DateTime.MinValue, DateTime.UtcNow);

            SolrQueryResults<DataEntry> results = new SolrQueryResults<DataEntry>(); 
            try
            {
                results = Solr.Query(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

			var updatedDocs = new List<DataEntry>();
			foreach (var doc in results)
			{
                doc.Tags = doc.Tags.Concat(new string[] {"Expired"}).ToArray(); //adds the expired tag
                doc.Tags = doc.Tags.Where(x => x != "Expires soon").ToArray(); //removes the expires soon tag
				updatedDocs.Add(doc);
			}
            try
            {
                // setting the updated units
                Solr.AddRange(updatedDocs);
                Solr.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
			
		}

        public void UpdateExpiredTagPlus()
        {
            // we need the units that have the Expired tag and the expiry field value is in the future or within the next 14 days from the current time
            var query = new SolrQueryByField("tags", "Expired") & new SolrQueryByRange<DateTime>("expiry", DateTime.UtcNow, DateTime.MaxValue) || new SolrQueryByRange<DateTime>("expiry", DateTime.UtcNow, DateTime.UtcNow.AddDays(14));
            
            SolrQueryResults<DataEntry> results = new SolrQueryResults<DataEntry>();

            try
            {
                results = Solr.Query(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            var updatedDocs = new List<DataEntry>();
            foreach (var doc in results)
            {
                doc.Tags = doc.Tags.Where(x => x != "Expired").ToArray(); //removes the expired tag
                updatedDocs.Add(doc);
            }

            try
            {
                // setting the updated units
                Solr.AddRange(updatedDocs);
                Solr.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdateExpiresSoonTagPlus()
        {
            // we need the units that has the Expires Soon tag and the value of the expiry field is after 14 days from the current date
            var query = new SolrQueryByField("tags", "Expires soon") & new SolrQueryByRange<DateTime>("expiry", DateTime.UtcNow.AddDays(14), DateTime.MaxValue);

            SolrQueryResults<DataEntry> results = new SolrQueryResults<DataEntry>();

            try
            {
                results = Solr.Query(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            var updatedDocs = new List<DataEntry>();
            foreach (var doc in results)
            {
                doc.Tags = doc.Tags.Where(x => x != "Expires soon").ToArray(); //removes the expires soon tag
                updatedDocs.Add(doc);
            }

            try
            {
                // setting the updated units
                Solr.AddRange(updatedDocs);
                Solr.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdateExpiressoonTagByDate()
		{
            // we need the units that doesn't have the Expired tag and the expiry field value is between the past and 14 days after the current time
			var query = !new SolrQueryByField("tags", "Expired") & new SolrQueryByRange<DateTime>("expiry", DateTime.MinValue, DateTime.UtcNow.AddDays(14));
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
