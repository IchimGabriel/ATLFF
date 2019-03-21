using ATLFFApp.API.Models;
using ATLFFApp.API.Models.Neo4j;
using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATLFFApp.API.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<IEnumerable<IRecord>> FindShortestPathAsync();
        Task<IEnumerable<IRecord>> TruckConnectedCityNeighbours();
        Task<IEnumerable<IRecord>> FindSPathAsync(string departureCity, string arrivalCity, string relation, int noNodes);
    } 
}