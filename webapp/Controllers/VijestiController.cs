using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using rentacar.Data;
using rentacar.Models;
using rentacar.ViewModels;

namespace rentacar.Areas.Admin.Controllers
{
    public class VijestiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public VijestiController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;

        }

        public IActionResult Index()
        {
            ViewData["deleteStatus"] = TempData["deleteStatus"];
            var model = _context.Novosti.OrderByDescending(d => d.DatumKreiranja).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(NewsViewModel model)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(w => w.Id == _userManager.GetUserId(HttpContext.User));
            Novosti newNews = new Novosti()
            {
                Sadržaj = model.Sadrzaj,
                DatumKreiranja = DateTime.Now,
                Autor = user.UserName.Substring(0, user.UserName.IndexOf("@")),
               // Sažetak = (model.Sadrzaj.Length > 80 ? model.Sadrzaj.Substring(0, 80) : model.Sadrzaj) + "...",
                Naslov = model.Naslov,
            };


            if (model.Slika != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                var uniqueName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
                string filepath = Path.Combine(uploadsFolder, uniqueName);
                string url = $"/images/{uniqueName}";
                newNews.ImagePath = url;

                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    model.Slika.CopyTo(fs);
                    fs.Flush();
                }

            }
            await _context.Novosti.AddAsync(newNews);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            NewsViewModel model = _context.Novosti.Where(w => w.Id == id).Select(s => new NewsViewModel()
            {
                Sadrzaj = s.Sadržaj,
                DatumKreiranja = s.DatumKreiranja,
                ImagePath = s.ImagePath,
                Naslov = s.Naslov
            }).Single();
            return View(model);
        }

        
    }
}
