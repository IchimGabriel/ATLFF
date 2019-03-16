using ATLFFApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ATLFFApp.WebUI.Services
{
    public interface IApiClient
    {
        Task<List<City>> GetAllCitiesAsync();
        
    }
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _HttpClient;

        public ApiClient(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>RETURN ALL CITIES IN NEO4J DB</returns>
        public async Task<List<City>> GetAllCitiesAsync()
        {
            var response = await _HttpClient.GetAsync("/api/City");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<City>>();
        }

    }
}
