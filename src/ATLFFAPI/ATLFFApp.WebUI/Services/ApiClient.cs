using ATLFFApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient _HttpClient;

        public ApiClient(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        /// <summary>
        /// GET: 
        /// </summary>
        /// <returns>RETURN ALL CITIES IN NEO4J DB</returns>
        public async Task<List<City>> GetAllCitiesAsync()
        {
            var response = await _HttpClient.GetAsync("/api/City");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<City>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departure"></param>
        /// <param name="arrival"></param>
        /// <param name="medium"></param>
        /// <param name="nrnodes"></param>
        /// <returns></returns>
        public async Task<List<ShortestPath>> GetSPath(string departure, string arrival, string medium, int nrnodes)
        {
            var response = await _HttpClient.GetAsync("/api/spath/" + departure + "/" + arrival + "/" + medium + "/" + nrnodes);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<ShortestPath>>();
        }
    }
}
