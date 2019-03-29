﻿using System;
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
                var result = session.ReadTransaction(tx => tx
                .Run("MATCH (a:city)-[:TRUCK]-(b:city) RETURN a.name AS Node, b.name AS Neighbour ORDER BY a.name ASC"));

                return result;   
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
        /// <returns>Test</returns>
        public async Task<IEnumerable<IRecord>> FindShortestPathAsync()
        {
            var session = db.Driver.Session();
            try
            {
                var result = session.ReadTransaction(tx => tx
                .Run("MATCH p = (a:city {name: 'Tralee'})-[r:TRUCK*1..7]-(b:city {name: 'Liverpool'})" +
                                $" RETURN extract(n IN nodes(p) | n.name) AS Cities," +
                                $" extract(r IN relationships(p) | r.distance) AS TravelDistance" + 
                                $" ORDER BY TravelDistance ASC"));
                
                return result;
            }
            catch (Exception e) { throw new SystemException(e.Message); }
            finally { await session.CloseAsync(); }

        }

        /// <summary>
        /// Query - SHORTEST PATH BETWEEN TWO CITIES
        /// </summary>
        /// <returns>Travel Nodes and total travel distance - KM </returns>
        public async Task<IEnumerable<IRecord>> FindSPathAsync(string departureCity, string arrivalCity, string relation, int noNodes)
        {
            var session = db.Driver.Session();
            try
            {
                var result = session.ReadTransaction(tx => tx
                .Run("MATCH p = (a:city {name:'" + departureCity + "'})-[r:" + relation + "*1.." + noNodes + "]-(b:city {name:'" + arrivalCity + "'})" +
                                " RETURN extract(n IN nodes(p) | n.name) AS Cities," +
                                " reduce(distance = 0, r IN relationships(p) | distance + r.distance) AS TravelDistance" +
                                " ORDER BY TravelDistance ASC"));

                return result;
            }
            catch (Exception e) { throw new SystemException(e.Message); }
            finally { await session.CloseAsync(); }

        }

        /// <summary>
        /// Create New Node
        /// </summary>
        /// <param name="city"></param>
        /// <param name="iso"></param>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="is_port"></param>
        /// <param name="turnaround"></param>
        /// <returns></returns>
        public async Task CreateNode(string city, string iso, float lat, float lng, bool is_port, int turnaround)
        {
            var session = db.Driver.Session();
            try
            {
                var result = session.WriteTransaction(tx => tx
                .Run("CREATE("+ city +": city{ name: '"+ city +"', iso: '"+ iso +"', lat: "+ lat +" , lng: "+ lng +", port_city: "+ is_port +", turnaround: "+ turnaround +"})"));
            }
            catch (Exception e) { throw new SystemException(e.Message); }
            finally
            { await session.CloseAsync(); }
        }

        /// <summary>
        /// Create Edge between two Cities
        /// </summary>
        /// <param name="fromCity"></param>
        /// <param name="toCity"></param>
        /// <param name="media"></param>
        /// <param name="distance"></param>
        /// <param name="price"></param>
        /// <param name="cotwo"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public async Task CreateEdge(string fromCity, string toCity, string media, int distance, decimal price, float cotwo, int speed)
        {
            var session = db.Driver.Session();
            try
            {
                var result = session.WriteTransaction(tx => tx
                .Run("MATCH (a:city), (b:city) WHERE a.name = '"+ fromCity +"' AND b.name = '"+ toCity +"' " +
                "CREATE(a) -[r: "+ media +" { distance: "+ distance +", price: "+ price +", cotwo: "+ cotwo +", speed: "+ speed +"}]->(b)"));
            }
            catch (Exception e) { throw new SystemException(e.Message); }
            finally
            { await session.CloseAsync(); }
        }
    }
}
