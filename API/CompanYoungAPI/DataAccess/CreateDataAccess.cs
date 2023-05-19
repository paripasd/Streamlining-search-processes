using CommonServiceLocator;
using CompanYoungAPI.Model;
using SolrNet;

namespace CompanYoungAPI.DataAccess
{
    public class CreateDataAccess
    {
        ISolrOperations<DataEntry> Solr;

        public CreateDataAccess()
        {
            Solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
        }

        public void CreateInstance(DataEntry data)
        {
			try
			{
				Solr.Add(data);
				Solr.Commit();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
    }
}
