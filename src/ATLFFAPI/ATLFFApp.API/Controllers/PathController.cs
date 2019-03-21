using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATLFFApp.API.Models;
using ATLFFApp.API.Models.Neo4j;
using ATLFFApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;

namespace ATLFFApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly ICityRepository db;
       
        public PathController(ICityRepository context)
        {
            db = context;
        }

        /// <summary>
        /// Conected Cities - neighbours
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetConnectedCities()
        {
            var req = await db.TruckConnectedCityNeighbours();
            return Ok(req);
        }

        /// <summary>
        /// Shortest Path from a city to city - hard coded cities for test
        /// </summary>
        /// <returns></returns>
        [Route("/api/shortpath")]
        [HttpGet]
        public async Task<IActionResult> GetShortesrPath() 
        {
            var result = await db.FindShortestPathAsync();
            return Ok(result);
        }

        /// <summary>
        /// Shortest Path using params
        /// </summary>
        /// <param name="departure">Dublin, Tralee</param>
        /// <param name="arrival">Liverpool</param>
        /// <param name="medium">TRUCK / TRAIN / SHIP / BARGE</param>
        /// <param name="nrnodes"> int - e.g. 7 </param>
        /// <returns> List of Shortest Paths between cities</returns>
        [Route("/api/spath/{departure}/{arrival}/{medium}/{nrnodes}")]
        [HttpGet]
        public async Task<IActionResult> GetSPath(string departure, string arrival, string medium, int nrnodes)
        {
            var result = await db.FindSPathAsync(departure, arrival, medium, nrnodes);
            return Ok(result);
        }

    }
}