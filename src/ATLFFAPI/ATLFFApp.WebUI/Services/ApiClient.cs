using ATLFFApp.WebUI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ATLFFApp.WebUI.Services
{
    /// <summary>
    /// Implemented HTTP API calls to receive data from Neo4J DB
    /// </summary>
    public interface IApiClient
    {
        Task<List<City>> GetAllCitiesAsync();
        Task<List<ShortestPath>> GetSPath(string departure, string arrival, string medium, int nrnodes);
        Task<IEnumerable<Neighbours>> TruckConnectedCityNeighbours();

    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient _HttpClient;

        public ApiClient(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        /// <summary>
        /// GET: All Nodes
        /// </summary>
        /// <returns>RETURN ALL CITIES IN NEO4J DB</returns>
        public async Task<List<City>> GetAllCitiesAsync()
        {
            var response = await _HttpClient.GetAsync("/api/city");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<City>>();
        }

        /// <summary>
        /// Get: Option Route 
        /// </summary>
        /// <param name="departure"></param>
        /// <param name="arrival"></param>
        /// <param name="media"></param>
        /// <param name="nrnodes"></param>
        /// <returns></returns>
        public async Task<List<ShortestPath>> GetSPath(string departure, string arrival, string media, int nrnodes)
        {
            var response = await _HttpClient.GetAsync("/api/spath/" + departure + "/" + arrival + "/" + media + "/" + nrnodes);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<ShortestPath>>();
        }

        /// <summary>
        /// GET: All cities connected by TRUCK
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Neighbours>> TruckConnectedCityNeighbours()
        {
            var response = await _HttpClient.GetAsync("/api/neighbours");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<IEnumerable<Neighbours>>();
        }
    }
}
