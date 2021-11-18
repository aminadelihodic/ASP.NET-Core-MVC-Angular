using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.Data;
using rentacar.Models;
using rentacar.ViewModels;
using Microsoft.EntityFrameworkCore;
using rentacar.Services;

namespace rentacar.Controllers
{
    public class CarsListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsListController(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            List<Automobil> data = await _context.Automobil.ToListAsync();
            List<AutomobiliViewModel> model = new List<AutomobiliViewModel>();

            if (data == null)
                return View(model);

            foreach (var item in data)
            {
                AutomobiliViewModel tmp = new AutomobiliViewModel();

                tmp.Id = item.Id;
                tmp.Name = item.Naziv;
                tmp.Price = item.Cijena;
                tmp.Description = item.Opis;
                tmp.Amount = item.IznosZarade;
                tmp.KategorijaId = item.KategorijaID;

                tmp.Slike = _context.Slika.Select(x => new Slika
                {
                    Id = x.Id,
                    AutomobilId = x.AutomobilId,
                    Url = x.Url
                }).Where(s => s.AutomobilId == tmp.Id).ToList();

                model.Add(tmp);
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Automobil
                .FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            CarCommentViewModel cm = new CarCommentViewModel();

            cm.CarFeatures = new CarFeaturesDetailsViewModel()
            {
                Features = new List<DetaljiKarakteristika>(),
                CarId = car.Id,
                CarName = car.Naziv,
                Description = car.Opis,
                Price = car.Cijena,
                ProfitAmount = car.IznosZarade,
                Category = _context.Kategorija.Select(c => new Kategorija
                {
                    Id = c.Id,
                    Naziv = c.Naziv
                }).Where(p => p.Id == car.KategorijaID).FirstOrDefault(),
                Pictures = _context.Slika.Select(x => new Slika
                {
                    Id = x.Id,
                    AutomobilId = x.AutomobilId,
                    Url = x.Url
                }).Where(s => s.AutomobilId == id).ToList()

            };

            cm.CarId = id.Value;
            cm.Title = car.Naziv;

            var Comments = _context.KomentariAutomobila.Where(d => d.AutomobilId.Equals(id.Value)).ToList();
            cm.ListOfComments = Comments;

            var ratings = _context.KomentariAutomobila.Where(d => d.AutomobilId.Equals(id.Value)).ToList();
            if (ratings.Count > 0)
            {
                var ratingSum = ratings.Sum(d => d.Ocjena);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }

            return View(cm);
        }

        /*public async Task<IActionResult> SendEmail(string message, string ccMail)
        {

            EmailSender.SendEmail("", message, ccMail);

            return RedirectToAction("Index", "CarsList");
        }*/

    }
}
