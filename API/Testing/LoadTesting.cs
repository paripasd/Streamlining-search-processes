using CommonServiceLocator;
using SolrNet.Commands.Parameters;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanYoungAPI.Model;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using SolrNet.Impl;
using Xunit.Abstractions;

namespace Testing
{
    public class LoadTesting
    {
        ISolrOperations<DataEntry> solr;
        ITestOutputHelper output;
        public LoadTesting(ITestOutputHelper output)
        {
            var connection = new SolrConnection("http://localhost:8983/solr/testing");
            Startup.Init<DataEntry>(connection);
            solr = ServiceLocator.Current.GetInstance<ISolrOperations<DataEntry>>();
            this.output = output;
        }

        /*
          Simulates x number of users simultaniously calling solr and getting back large datasets
          and checking query time at solr when under heavy load.
         */
        [Fact]
        public void TestSolrPerformance()
        {
            int numberOfThreads = 8; 

            var threads = new Thread[numberOfThreads];

            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i] = new Thread(() =>
                {
                    var query = new SolrQuery("*:*");
                    var options = new QueryOptions
                    {
                        Rows = 871
                    };

                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var results = solr.Query(query, options);
                    stopwatch.Stop();
                    output.WriteLine("Query Time: " + stopwatch.ElapsedMilliseconds);
                    Assert.True(results.Capacity == 871);
                    Assert.True(stopwatch.ElapsedMilliseconds < 3000, $"Query took too long ({stopwatch.ElapsedMilliseconds}ms)");
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            /*Parallel.ForEach(Enumerable.Range(1, 1000), i => {
                var query = new SolrQuery("*:*");
                var options = new QueryOptions
                {
                    Rows = 871
                };

                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var results = solr.Query(query, options);
                stopwatch.Stop();
                output.WriteLine("Parallel Query Time: " + stopwatch.ElapsedMilliseconds);
                Assert.True(results.Capacity == 871);
                Assert.True(stopwatch.ElapsedMilliseconds < 1500, $"Query {i} took too long ({stopwatch.ElapsedMilliseconds}ms)");
            });*/
        }
    }
}
