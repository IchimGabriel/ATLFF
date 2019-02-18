using ATLFF.Core.Model;
using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATLFFConsoleApp
{
    class Program : IEnumerable
    {
        static void Main(string[] args)
        {

          

           // var client = new BoltGraphClient("bolt://atlasff.ovh:7687", "neo4j", "Vrabierobert75##");
           // client.Connect();

           // var cities = client.Cypher
           //.Match("(city:city)")
           //.Return(city => city.As<City>())
           //.Results;

           // foreach (var item in cities)
           // {
           //     Console.WriteLine($"\nCity: {item.Name}, - {item.Latitude} - {item.Longitude}");
           // }

            RunAsync().GetAwaiter().GetResult();
 
            Console.ReadLine();
        }

        public static async Task RunAsync()
        {
            // binary connection to BD
            var client = new BoltGraphClient("bolt://atlasff.ovh:7687", "neo4j", "");

            // web intreface connection
            //GraphClient client = new GraphClient(new Uri("http://atlasff.ovh:7474/db/data"), "neo4j", "");
            client.Connect();

            // Cities connected by SHIP
            //var cities_conected_by_ship = client.Cypher
            //                            .Match("(a:city)-[r:SHIP]-(b)")
            //                            .With("a, COUNT(r) AS count")
            //                            .Return((a) => a.As<City>())
            //                            .Results;

            //Console.WriteLine($"\nCities connected by SHIP:-\n");

            //foreach (var item in cities_conected_by_ship)
            //{
            //    Console.WriteLine($"\nCity: {item.Name}, - {item.Latitude}/{item.Longitude} - Overhead: - {item.Turnaround}");
            //}

            // Shortest path from Limerick To Liverpool 
            var query = client.Cypher
            .Match("path = shortestPath((a:city)-[:TRUCK*]-(b:city))")
            .Where((City a) => a.Name == "Limerick")
            .AndWhere((City b) => b.Name == "Liverpool")
            .Return(() => Return.As<IEnumerable<string>>("[n IN nodes(path) | n.name]"));

            var result = query.Results;

            foreach (var value in result)
            {
                Console.WriteLine(value);  //Limerick - Dublin - Dundalk - Belfast - Glasgow - Liverpool
            }

         

        }

        public IEnumerator GetEnumerator()
        {
            return null;
        }
    }
}
