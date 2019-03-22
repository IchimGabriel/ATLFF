using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATLFFApp.WebUI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ATLFFApp.WebUI.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Roles
        /// </summary>
        /// <returns>List of Roles</returns>
        [HttpGet]
        public IActionResult Index()
        {
           
            var Roles = _context.Roles.ToList();
            return View(Roles);
        }

        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            //if (!User.Identity.IsAuthenticated && !IsAdminUser())
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
		/// Create a New Role
		/// </summary>
		/// <param name="Role"></param>
		/// <returns></returns>
		[HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult Create(IdentityRole Role)
        {
            //if (!User.Identity.IsAuthenticated && !IsAdminUser())
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            _context.Roles.Add(Role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}