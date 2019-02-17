using ATLFF.Core.Connection;
using System;
using ATLFF.Core;
using System.Threading.Tasks;
using ATLFF.Core.Model;
using System.Collections.Generic;
using Neo4jClient;

namespace ATLFFConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            RunAsync().GetAwaiter().GetResult();

            Console.ReadLine();

        }

        public static async Task RunAsync()
        {
         
            GraphClient client = new GraphClient(new Uri("http://atlasff.ovh:7474/db/data"), "neo4j", "");
            client.Connect();

            var result = client.Cypher
            .Match("(city:city)")
            .Return(city => city.As<City>())
            .Results;

            foreach (var item in result)
            {
                Console.WriteLine($"\nCity: {item.Name}, - {item.Latitude} - {item.Longitude}");
            }
        }
        
    }
}
