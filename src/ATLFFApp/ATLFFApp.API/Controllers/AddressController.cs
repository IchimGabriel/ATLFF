using System;
using System.Linq;
using System.Threading.Tasks;
using ATLFFApp.API.Data;
using ATLFFApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ATLFFApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        ShipmentContext db;

        public AddressController(ShipmentContext context)
        {
            db = context;
        }
        // GET: api/Address
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var addresses = db.Addresses.ToList();
            await Task.Delay(0);
            return Ok(addresses);
        }

        // GET: api/Address/5
        [HttpGet("{id}", Name = "Get")]
        public Address Get(Guid id)
        {
            return db.Addresses.FirstOrDefault(x => x.Address_Id.Equals(id));
        }

        // POST: api/Address
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

        // PUT: api/Address/5
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

        // DELETE: api/ApiWithActions/5
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
