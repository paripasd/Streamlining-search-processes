using CommonServiceLocator;
using CompanYoungAPI.DataAccess;
using CompanYoungAPI.Model;
using SolrNet;
using SolrNet.Exceptions;
using SolrNet.Impl;
using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Testing
{
    public class Update
    {
        ISolrOperations<DataEntry> solr;
        UpdateDataAccess uda;
        ITestOutputHelper output;
        public Update(ITestOutputHelper output)
        {
            var connection = new SolrConnection("http://localhost:8983/solr/testing");
            Startup.Init<DataEntry>(connection);
            solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
            uda = new UpdateDataAccess();
            this.output = output;
        }

        [Fact]
        public void UpdateUnit() // based on ID
        {
            //initial declarations
            DataEntry unitAfterChange = new DataEntry();
            DataEntry oldUnit = new DataEntry();
            DataEntry newUnit = new DataEntry();
            var allData = new List<DataEntry>();
            bool isInCollection = false;

            //create new unit
            string[] path = { "" };
            string[] tags = { "" };

            newUnit.Id = ""; //must be the same id as the old unit
            newUnit.Path = path; //required
            newUnit.Tags = tags; //required
            newUnit.Expiry = DateTime.Now.AddDays(14); //required
            newUnit.Question = ""; // change
            // + add more change if necesary

            try
            {
                //get all data
                allData = solr.Query("*:*");
            }
            catch (SolrConnectionException ex)
            {
                Assert.True(false, ex.Message); // test fail if connection problem
            }

            //loop through all data and get old unit that we want to update, based on Id
            foreach (DataEntry unit in allData)
            {
                if (unit.Id.Equals(newUnit.Id))
                {
                    oldUnit = unit;
                    isInCollection = true;
                }
            }
            Assert.True(isInCollection, "Unit doesn't exist"); // test fail if we dont find anything

            try
            {
                // do update and get the full updated object
                uda.UpdateInstance(newUnit);
                unitAfterChange = solr.Query("id:" + newUnit.Id).First();
            }
            catch (SolrConnectionException ex)
            {
                Assert.True(false, ex.Message); // test fail if connection problem
            }

            // output for version numbers
            output.WriteLine("Old version number:" + oldUnit.Version);
            output.WriteLine("New version number:" + unitAfterChange.Version);

            // Update test is successful if the version number changed
            Assert.NotEqual(oldUnit.Version, unitAfterChange.Version);
        }
    }
}
