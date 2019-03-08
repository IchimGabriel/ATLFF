using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATLFFApp.API.Models;
using ATLFFApp.API.Models.Neo4j;
using ATLFFApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATLFFApp.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository db;

        public CityController(ICityRepository context)
        {
            db = context;
        }

        /// <summary>
        /// GET: api/City
        /// </summary>
        /// <returns>ALL CITIES AS NODES</returns>
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var city = await db.GetAllCities();
            return Ok(city.ToList());
        }
    }
}
