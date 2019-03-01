using System;
using System.Linq;
using System.Threading.Tasks;
using ATLFFApp.API.Data;
using ATLFFApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATLFFApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "admin")]
    public class AddressController : ControllerBase
    {
        private ShipmentContext db;

        public AddressController(ShipmentContext context)
        {
            db = context;
        }
        
        /// <summary>
        /// GET: api/Address
        /// </summary>
        /// <returns>List of Addresses in DB</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var addresses = db.Addresses.ToList();
            await Task.Delay(0);
            return Ok(addresses);
        }


        /// <summary>
        /// GET: api/Address/6747c5d9-e476-4e0e-831a-63c0bd747d7c
        /// </summary>
        /// <param name="id">GUID</param>
        /// <returns>An Address with the request GUID</returns>
        [HttpGet("{id}", Name = "Get")]
        public Address Get(Guid id)
        {
            return db.Addresses.FirstOrDefault(x => x.Address_Id.Equals(id));
        }

        
        /// <summary>
        /// POST: api/Address
        /// </summary>
        /// <param name="address"></param>
        /// <returns>POST a new Address</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            address.Address_Id = Guid.NewGuid();

            db.Addresses.Add(address);
            db.SaveChanges();

            return Ok();
        }

        
        /// <summary>
        /// PUT: api/Address/6747c5d9-e476-4e0e-831a-63c0bd747d7c
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns>Update an Address</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Address address)
        {
            if (!db.Addresses.Any(t => t.Address_Id == id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            address.Address_Id = id;
            db.Addresses.Update(address);
            await db.SaveChangesAsync();

            return Ok();

        }

        
        /// <summary>
        /// DELETE: api/ApiWithActions/6747c5d9-e476-4e0e-831a-63c0bd747d7c
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Remove the record with id = 6747c5d9-e476-4e0e-831a-63c0bd747d7c</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var address = db.Addresses.Find(id);

            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            db.SaveChanges();

            return NoContent();
        }
    }
}
