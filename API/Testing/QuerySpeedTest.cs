using CommonServiceLocator;
using SolrNet.Impl;
using SolrNet;
using CompanYoungAPI.Model;
using SolrNet.Commands.Parameters;
using System.Diagnostics;
using System.Linq;
using System;
using Xunit.Abstractions;

namespace Testing
{
    public class QuerySpeedTest
    {
        ISolrOperations<DataEntry> solr;
        ITestOutputHelper output;
        public QuerySpeedTest(ITestOutputHelper output)
        {
            var connection = new SolrConnection("http://localhost:8983/solr/testing");
            Startup.Init<DataEntry>(connection);
            solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
            this.output = output;
        }

        /*
          Queries all (871 unit for now) instances in the database 100 times and checks
          if the query time is below 200 miliseconds and prints out
          each query time and the average.
         */
        [Fact]
        public void QuerySpeed()
        {
            var queryOptions = new QueryOptions
            {
                Rows = 871 // set the number of rows to return
            };
            var query = new SolrQuery("*:*");

            List<long> queryTimes = new List<long>();
            SolrQueryResults<DataEntry> results = new SolrQueryResults<DataEntry>();

            for (int i = 0; i < 100; i++)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                results = solr.Query(query, queryOptions);
                stopwatch.Stop();
                queryTimes.Add(stopwatch.ElapsedMilliseconds);
                Assert.True(results.Capacity == 871);
            }
            
            double average = queryTimes.Average();
            foreach (long time in queryTimes)
            {
                output.WriteLine("Query Time: " + time + "ms");
            }
            output.WriteLine("Average: " + average);
            Assert.True(average < 200);
        }
    }
}