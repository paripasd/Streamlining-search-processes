using CommonServiceLocator;
using CompanYoungAPI.DataAccess;
using CompanYoungAPI.Model;
using SolrNet;
using SolrNet.Exceptions;
using SolrNet.Impl;
using Xunit.Abstractions;

namespace Testing
{
    public class Create
    {
        ISolrOperations<DataEntry> solr;
        CreateDataAccess cda;
        ITestOutputHelper output;

        public Create(ITestOutputHelper output)
        {
            var connection = new SolrConnection("http://localhost:8983/solr/testing");
            Startup.Init<DataEntry>(connection);
            solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
            cda = new CreateDataAccess();
            this.output = output;
        }

        [Fact]
        public void CreateUnit()
        {
            DataEntry newUnit = new DataEntry(); 
            DataEntry unitInDb = new DataEntry();
            // required properties to create
            newUnit.Id = Guid.NewGuid().ToString();
            newUnit.Question = "";
            string[] path = { "" };
            string[] tags = { "" };
            newUnit.Path = path;
            newUnit.Tags = tags;
            newUnit.Expiry = DateTime.Now.AddDays(14);

            try
            {
                // do create
                cda.CreateInstance(newUnit);
                // get back created unit from DB, based on ID
                unitInDb = solr.Query("id:" + newUnit.Id).First();
            }
            catch (SolrConnectionException ex)
            {
                Assert.True(false, ex.Message); // test fail if connection problem
            }

            // output for ID's
            output.WriteLine("ID in the code:" + newUnit.Id);
            output.WriteLine("ID in the DB:" + unitInDb.Id);

            // if created unit in DB is not null the creation test was successful
            Assert.Equal(newUnit.Id, unitInDb.Id);
        }
    }
}
