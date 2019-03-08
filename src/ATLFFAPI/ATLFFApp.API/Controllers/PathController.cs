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
            var req = db.TruckConnectedCityNeighbours();
            await Task.Delay(0);
            return Ok(req);
        }

        /// <summary>
        /// Shortest Path from a city to city
        /// </summary>
        /// <returns></returns>
        [Route("/api/shortpath")]
        [HttpGet]
        public async Task<IActionResult> GetShortesrPath() 
        {
            await Task.Delay(0);
            return Ok(db.FindShortestPathAsync());
        }

    }
}