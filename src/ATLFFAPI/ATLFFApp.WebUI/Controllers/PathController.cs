using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATLFFApp.WebUI.Services;
using ATLFFApp.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace ATLFFApp.WebUI.Controllers
{
    public class PathController : Controller
    {
        private readonly IApiClient _client;
        //private readonly ILogger<ShortestPathRequestModel> _logger;

        public PathController(IApiClient client, ILogger<ShortestPathRequestModel> logger)
        {
            _client = client;
           // _logger = logger;
        }

        [BindProperty]
        public ShortestPathRequestModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

       [HttpGet]
        public async Task<IActionResult> OnGetAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _client.GetSPath(Input.DepartureCity, Input.ArrivalCity, Input.Medium, Input.NoNodes);
  
            return View(result);
        }
    }
}