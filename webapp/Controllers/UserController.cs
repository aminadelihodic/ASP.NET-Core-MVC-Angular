using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using rentacar.Data;
using rentacar.Models;
using rentacar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["success"] = TempData["success"];
            CarsRentViewModel model = new CarsRentViewModel()
            {
                Iznajmljivanje = new IznajmljivanjeViewModel()
                {
                    Cars = _context.Automobil.Select(s => new SelectListItem()
                    {
                        Text = s.Naziv,
                        Value = s.Id.ToString()
                    }).ToList()
                },
                Automobili = _context.Automobil.Select(c => new AutomobiliViewModel()
                {
                    Id = c.Id,
                    Name = c.Naziv,
                    Amount = c.IznosZarade,
                    Kategorija = c.Kategorija,
                    Description = c.Opis,
                    Price = c.Cijena,
                    Slike = _context.Slika.Select(x => new Slika
                    {
                        Id = x.Id,
                        AutomobilId = x.AutomobilId,
                        Url = x.Url
                    }).Where(s => s.AutomobilId == c.Id).ToList()
                })

            };

            return View(model);
        }
    }
}
