using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATLFFApp.API.Models.Neo4j;
using Neo4j.Driver.V1;
using Neo4jClient;

namespace ATLFFApp.API.Repositories.Neo4j
{
    public class CityRepository : ICityRepository
    {
        private readonly IGraphRepository db;
        public CityRepository(IGraphRepository context) 
        {
            db = context;
        }
        /// <summary>
        /// RETURN ALL NODES(CITIES) IN DATABASE
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<City>> GetAllCities()
        {
            var _client = new BoltGraphClient(new Uri("bolt://atlasff.ovh:7687"), "neo4j", "");
            _client.Connect();
            try
            {
                var query = (await _client.Cypher
                       .Match("(city:city)")
                       .Return(city => city.As<City>())
                       .ResultsAsync);

                return query;
            }
            catch (Exception e) { throw new SystemException(e.Message);}
            finally { _client.Dispose(); }   
        }

        /// <summary>
        /// Query - using transaction - Return Node and Neighbours
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IRecord>> TruckConnectedCityNeighbours() 
        {
            var session = db.Driver.Session();
            try
            {
                var cityNeighbours = session.ReadTransaction(tx => tx
                .Run("MATCH (a:city)-[:TRUCK]-(b:city) RETURN a.name AS Node, b.name AS Neighbour ORDER BY a.name ASC"));

                return cityNeighbours;   
            }
            catch (Exception e) { throw new SystemException(e.Message); }
            finally
            {
                // asynchronously close session
                await session.CloseAsync();
            }
            
        }

        /// <summary>
        /// Query - SHORTEST PATH BETWEEN TWO CITY
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IRecord>> FindShortestPathAsync()
        {
            var session = db.Driver.Session();
            try
            {
                var shortestPath = session.ReadTransaction(tx => tx
                .Run("MATCH p = (a:city {name: 'Tralee'})-[r:TRUCK*1..7]-(b:city {name: 'Liverpool'})" +
                                $" RETURN extract(n IN nodes(p) | n.name) AS Cities," +
                                $" extract(r IN relationships(p) | r.distance) AS TravelDistance" + 
                                $" ORDER BY TravelDistance ASC"));
                
                return shortestPath;
            }
            catch (Exception e) { throw new SystemException(e.Message); }
            finally { await session.CloseAsync(); }

        }

        /// <summary>
        /// Query - SHORTEST PATH BETWEEN TWO CITY
        /// </summary>
        /// <returns>Travel Nodes and total travel distance - KM </returns>
        public async Task<IEnumerable<IRecord>> FindSPathAsync(string departureC, string arrivalC, string relation, int nrnodes)
        {
            var session = db.Driver.Session();
            try
            {
                var shortestPath = session.ReadTransaction(tx => tx
                .Run("MATCH p = (a:city {name:'" + departureC + "'})-[r:" + relation + "*1.." + nrnodes + "]-(b:city {name:'" + arrivalC + "'})" +
                                $" RETURN extract(n IN nodes(p) | n.name) AS Cities," +
                                $" reduce(distance = 0, r IN relationships(p) | distance + r.distance) AS TravelDistance" +
                                $" ORDER BY TravelDistance ASC"));

                return shortestPath;
            }
            catch (Exception e) { throw new SystemException(e.Message); }
            finally { await session.CloseAsync(); }

        }
    }
}
