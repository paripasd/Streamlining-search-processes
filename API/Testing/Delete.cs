using CommonServiceLocator;
using CompanYoungAPI.Model;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using SolrNet.Impl;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using SolrNet.Exceptions;
using CompanYoungAPI.DataAccess;

namespace Testing
{
    public class Delete
    {
        ISolrOperations<DataEntry> solr;
        DeleteDataAccess dda;
        public Delete()
        {
            var connection = new SolrConnection("http://localhost:8983/solr/testing");
            Startup.Init<DataEntry>(connection);
            solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
            dda = new DeleteDataAccess();
        }

        [Fact]
        public void DeleteUnit()
        {
            var idToDelete = "045095de-c710-4f2a-a409-c75a7693b2af"; // required
            var allData = new List<DataEntry>();

            bool isInCollection = false;
            try
            {
                // get all data
                allData = solr.Query("*:*");
            }
            catch (SolrConnectionException ex)
            {
                Assert.True(false, ex.Message); // test fail if connection problem
            }
            //loop through all data and check if unit exists
            foreach (DataEntry unit in allData)
            {
                if (unit.Id.Equals(idToDelete))
                {
                    isInCollection = true;
                }
            }
            Assert.True(isInCollection,"Unit doesn't exist"); // test fail if we dont find anything

            try
            {
                // do delete
                dda.DeleteById(idToDelete);
            }
            catch (SolrConnectionException ex)
            {
                Assert.True(false, ex.Message); // test fail if connection problem
            }

            // if query for the deleted unit id is empty than test is successful
            Assert.Empty(solr.Query("id:"+idToDelete));
        }
    }
}
