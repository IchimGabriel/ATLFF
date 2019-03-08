using ATLFF.Core.Model;
using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATLFFConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ListOfCitiesRunAsync().GetAwaiter().GetResult();
            CitiesConectedByShipAsync().GetAwaiter().GetResult();
            ShortestPathRunAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }

        public static async Task ListOfCitiesRunAsync()
        {
            // binary connection to BD
            var client = new BoltGraphClient("bolt://atlasff.ovh:7687", "neo4j", "");
            client.Connect();

            var cities = client.Cypher
                       .Match("(city:city)")
                       .Return(city => city.As<City>())
                       .Results;

            Console.WriteLine($"\nList of Nodes:");

            foreach (var item in cities)
            {
                Console.WriteLine($"\nCity: {item.Name}, - {item.Latitude} - {item.Longitude}");
            }
            await Task.Delay(0);
        }

        public static async Task CitiesConectedByShipAsync()
        {
            // binary connection to BD
            var client = new BoltGraphClient("bolt://atlasff.ovh:7687", "neo4j", "");
            client.Connect();

            // Cities connected by SHIP
            var cities_conected_by_ship = client.Cypher
                                        .Match("(a:city)-[r:SHIP]-(b)")
                                        .With("a, COUNT(r) AS count")
                                        .Return((a) => a.As<City>())
                                        .Results;

            Console.WriteLine($"\n\n\nCities connected by SHIP:");

            foreach (var item in cities_conected_by_ship)
            {
                Console.WriteLine($"Id: {item.Id}, - City: {item.Name}, - {item.Latitude}/{item.Longitude} - Overhead: - {item.Turnaround}");
            }
            await Task.Delay(0);
        }

        public static async Task ShortestPathRunAsync()
        {
            // web intreface connection
            //GraphClient client = new GraphClient(new Uri("http://atlasff.ovh:7474/db/data"), "neo4j", "");
            // binary connection to BD
            var client = new BoltGraphClient("bolt://atlasff.ovh:7687", "neo4j", "");
            client.Connect();

            // Shortest path from Limerick To Liverpool 
            var query = client.Cypher
                        .Match("path = shortestPath((a:city)-[:TRUCK*]-(b:city))")
                        .Where((City a) => a.Name == "Limerick")
                        .AndWhere((City b) => b.Name == "Liverpool")
                        .Return(() => Return.As<IEnumerable<string>>("[n IN nodes(path) | n.name]"));

            var result = query.Results;

            Console.WriteLine($"\n\n\nShortest Path from Limerick to Liverpool: ");

            foreach (var value in result)
            {
                foreach (var item in value)
                {
                    Console.WriteLine($"\n {item}");  //Limerick - Dublin - Dundalk - Belfast - Glasgow - Liverpool
                }
            }

            await Task.Delay(0);
        }
    }
}

