using ATLFF.Core.Connection;
using ATLFF.Core.Model;
using ATLFF.Core.Serializer;
using Neo4j.Driver.V1;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ATLFF.Core
{
    public class Client : IDisposable
    {
        private readonly IDriver driver;

        public Client(ISettings settings)
        {
            driver = GraphDatabase.Driver(settings.Uri, settings.AuthToken);
        }

        public async Task CreateIndices()
        {
            string[] queries = {
                "CREATE INDEX ON :City(name)",
                "CREATE INDEX ON :Edge(id)"
            };


            using (var session = driver.Session())
            {
                foreach (var query in queries)
                {
                    await session.RunAsync(query);
                }
            }
        }

        public async Task ReturnNodes()
        {

            string query = "CREATE (n) RETURN n" ;

            using (ISession session = driver.Session())
            {
                await  session.RunAsync(query);
            }

        }

        public void Dispose()
        {
            driver?.Dispose();
        }
    }
}
