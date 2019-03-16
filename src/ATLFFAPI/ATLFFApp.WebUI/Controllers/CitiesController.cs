using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATLFFApp.WebUI.Data;
using ATLFFApp.WebUI.Models;
using ATLFFApp.WebUI.Services;

namespace ATLFFApp.WebUI.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IApiClient _client;

        public CitiesController(IApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// GET: Cities
        /// </summary>
        /// <returns>List of all CITIES in Neo4j DB</returns>
        
        public async Task<IActionResult> Index()
        {
            var cities = await _client.GetAllCitiesAsync();
            return View(cities);
        }



        //// GET: Cities/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var city = await _context.City
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(city);
        //}

        //// GET: Cities/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Cities/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Latitude,Longitude,iso,Port,Turnaround")] City city)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        city.Id = Guid.NewGuid();
        //        _context.Add(city);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(city);
        //}

        //// GET: Cities/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var city = await _context.City.FindAsync(id);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(city);
        //}

        //// POST: Cities/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Latitude,Longitude,iso,Port,Turnaround")] City city)
        //{
        //    if (id != city.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(city);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CityExists(city.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(city);
        //}

        //// GET: Cities/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var city = await _context.City
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(city);
        //}

        //// POST: Cities/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var city = await _context.City.FindAsync(id);
        //    _context.City.Remove(city);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CityExists(Guid id)
        //{
        //    return _context.City.Any(e => e.Id == id);
        //}
    }
}
