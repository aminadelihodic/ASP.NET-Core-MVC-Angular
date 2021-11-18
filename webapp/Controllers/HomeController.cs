using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using rentacar.Data;
using rentacar.Models;
using rentacar.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace rentacar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {

            IznajmljivanjeViewModel model = new IznajmljivanjeViewModel()
            {
                Cars = _context.Automobil.Select(s => new SelectListItem()
                {
                    Text = s.Naziv,
                    Value = s.Id.ToString()
                }).ToList()
            };
                
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData.Add("userId", user);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
