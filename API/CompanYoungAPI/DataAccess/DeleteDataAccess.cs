using CommonServiceLocator;
using CompanYoungAPI.Model;
using SolrNet;

namespace CompanYoungAPI.DataAccess
{
    public class DeleteDataAccess
    {
        ISolrOperations<DataEntry> Solr;

        public DeleteDataAccess()
        {
            Solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
        }

        public void DeleteById(string id) 
        {
            try
            {
                Solr.Delete(id);
                Solr.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
