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
    }
}
