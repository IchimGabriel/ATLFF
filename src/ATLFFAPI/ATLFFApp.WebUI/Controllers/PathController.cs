using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATLFFApp.WebUI.Services;
using ATLFFApp.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ATLFFApp.WebUI.Controllers
{
    public class PathController : Controller
    {
        private readonly IApiClient _client;
        private readonly ILogger<ShortestPathRequestModel> _logger;

        public PathController(IApiClient client, ILogger<ShortestPathRequestModel> logger)
        {
            _client = client;
            _logger = logger;
        }

        [BindProperty]
        public ShortestPathRequestModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Imput Query params
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGet()
        {
            //_logger.LogInformation("Input params...");

            IList<string> MediaList = new List<string> { "TRUCK", "TRAIN", "SHIP", "BARGE" };
            ViewBag.Media = new SelectList(MediaList);

            return View();
        }

        /// <summary>
        /// Display selection of routes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _client.GetSPath(Input.DepartureCity, Input.ArrivalCity, Input.Media, Input.NoNodes);

            ViewBag.Media = Input.Media.ToLower();
  
            return View(result);
        }
    }
}