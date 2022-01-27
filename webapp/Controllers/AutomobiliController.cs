using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rentacar.Data;
using rentacar.Models;
using rentacar.Services;
using rentacar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Controllers
{
    public class AutomobiliController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AutomobiliController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/Automobil
        public async Task<IActionResult> Index(string Proizvodjac)
        {
            var applicationDbContext = _context.Automobil
                .Include(a => a.Kategorija)
                .Include(a => a.Proizvodjac)
                .Include(a => a.Slike)
                .AsQueryable();

            if (Proizvodjac != null && Proizvodjac != "Svi proizvođači")
            {
                applicationDbContext = applicationDbContext.Where(x => x.Proizvodjac.Naziv == Proizvodjac);
            }
            else
            {
                Proizvodjac = "Svi proizvođači";
            }

            var ProizvodjaciList = await _context.Proizvodjac.ToListAsync();
            ProizvodjaciList.Insert(0, new Proizvodjac
            {
                Id = 0,
                Naziv = "Svi proizvođači"
            });
            ViewData["Proizvodjaci"] = ProizvodjaciList;
            ViewData["ProizvodjaciFilter"] = Proizvodjac;

            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Detalji(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Automobil
                .Include(a => a.Kategorija)
                .Include(a => a.Proizvodjac)
                .Include(a => a.Slike)
                .Include("KarakteristikeDetaljaAutomobila.DetaljiKarakteristika")
                .FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            CarCommentViewModel cm = new CarCommentViewModel();
            cm.CarFeatures = new CarFeaturesDetailsViewModel()
            {
                Features = _context.KarakteristikeDetaljaAutomobila
                .Where(s => s.AutomobilId == id)
                .Select(x => new DetaljiKarakteristika
                {
                    Naziv = x.DetaljiKarakteristika.Naziv
                }).ToList(),
                CarId = car.Id,
                CarName = car.Naziv,
                Description = car.Opis,
                Price = car.Cijena,
                ProfitAmount = car.IznosZarade,
                Manufacturer = car.Proizvodjac.Naziv,
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
                }).Where(s => s.AutomobilId == id).ToList(),


            };
            cm.CarId = id.Value;
            cm.Title = car.Naziv;

            var Comments = _context.KomentariAutomobila.Include(x => x.Korisnik).Where(d => d.AutomobilId.Equals(id.Value)).ToList();
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

        public async Task<IActionResult> SendEmail(string message, string ccMail)
        {

            MailHelper.SendMail("razvoj.softvera1@gmail.com", message, ccMail);

            return  RedirectToAction("Index", "Automobili");
        }
    }
}
