using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATLFFApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver.V1;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace ATLFFApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        // GET: api/Node
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var client = new BoltGraphClient("bolt://atlasff.ovh:7687", "neo4j", "");
            client.Connect();

            var cities = client.Cypher
                       .Match("(city:city)")
                       .Return(city => city.As<City>())
                       .Results;

            await Task.Delay(0);
            return Ok(cities);
        }

        [Route("path")]
        [HttpGet]
        public async Task<IActionResult> GetPathAsync()
        {
            //var driver = GraphDatabase.Driver(new Uri("bolt://atlasff.ovh:7687"), AuthTokens.Basic("neo4j", ""));
            var client = new BoltGraphClient("bolt://atlasff.ovh:7687", "neo4j", "");
            client.Connect();

            //Shortest path from Limerick To Liverpool
            var query = client.Cypher
                        .Match("path = shortestPath((a:city)-[:TRUCK*]-(b:city))")
                        .Where((City a) => a.Name == "Limerick")
                        .AndWhere((City b) => b.Name == "Liverpool")
                        .Return(() => Return.As<IEnumerable<string>>("[n IN nodes(path) | n.name]"));

            var result = query.Results;

            //using (var session = driver.Session())
            //{
            //    var result = session.Run("Match(path = shortestPath((a: city) -[:TRUCK *]-(b: city)))" +
            //        "Where((City a) => a.Name == 'Limerick')" +
            //        "AndWhere((City b) => b.Name == 'Liverpool')"
            //        + "Return(() => Return.As<IEnumerable<string>>('[n IN nodes(path) | n.name]'))");
            //    result.ToList();
            //}

            //List<string> city = new List<string>();
            ////await Task.Delay(0);
            //foreach (var value in result)
            //{
            //    foreach (var item in value)
            //    {
            //        city.Add(item);
            //        // Console.WriteLine($"\n {item}");  //Limerick - Dublin - Dundalk - Belfast - Glasgow - Liverpool
            //    }
            //}

            await Task.Delay(0);
            return Ok(result);
        }

    }
}
