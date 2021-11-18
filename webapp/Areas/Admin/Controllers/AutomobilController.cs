using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rentacar.Areas.Admin.ViewModels;
using rentacar.Data;
using rentacar.Models;
using rentacar.Services;

namespace rentacar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AutomobilController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment Environment;

        public AutomobilController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            Environment = environment;
        }

        // GET: Admin/Automobil
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Automobil.Include(a => a.Kategorija).Include(a=>a.Slike);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Automobil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .Include(a => a.Kategorija)
                .Include("KarakteristikeDetaljaAutomobila.DetaljiKarakteristika")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // GET: Admin/Automobil/Create
        public IActionResult Create()
        {
            var Model = new AutomobiliDodajVM
            {
                DetaljiKarakteristika = _context
                .DetaljiKarakteristika
                .Select(x => new DetaljiKarakteristikaVM
                {
                    DetaljiKarakteristikaId = x.Id,
                    Naziv = x.Naziv,
                    Oznaceno = false
                }).ToList()
            };

            ViewData["KategorijaID"] = new SelectList(_context.Kategorija, "Id", "Naziv");
            ViewData["ProizvodjacID"] = new SelectList(_context.Proizvodjac, "Id", "Naziv");
            return View(Model);
        }

        // POST: Admin/Automobil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutomobiliDodajVM VM, IFormFile SlikaUpload)
        {
            if (ModelState.IsValid)
            {
                _context.Add(VM.Automobil);

                if (SlikaUpload != null)
                {
                    string fileName = FileUploadHelper.SaveUploadedFile(SlikaUpload);

                    var NovaSlika = new Slika
                    {
                        Url = "Uploads/" + fileName,
                        Automobil = VM.Automobil
                    };
                    _context.Add(NovaSlika);

                }

                VM.Automobil.KarakteristikeDetaljaAutomobila = new List<KarakteristikeDetaljaAutomobila>();
                foreach (int KarakteristikaId in VM.OznaceneKarakteristike)
                {
                    var karakteristika = _context.DetaljiKarakteristika.Find(KarakteristikaId);
                    if (karakteristika != null)
                    {
                        VM.Automobil.KarakteristikeDetaljaAutomobila.Add(new KarakteristikeDetaljaAutomobila
                        {
                            DetaljiKarakteristikaId = KarakteristikaId
                        });
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategorijaID"] = new SelectList(_context.Kategorija, "Id", "Naziv", VM.Automobil.KategorijaID);
            ViewData["ProizvodjacID"] = new SelectList(_context.Proizvodjac, "Id", "Naziv");

            var Model = new AutomobiliDodajVM
            {
                Automobil = VM.Automobil,
                DetaljiKarakteristika = _context
                .DetaljiKarakteristika
                .Select(x => new DetaljiKarakteristikaVM
                {
                    DetaljiKarakteristikaId = x.Id,
                    Naziv = x.Naziv,
                    Oznaceno = false
                }).ToList()
            };

            return View(VM);
        }

        // GET: Admin/Automobil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .Include(x => x.KarakteristikeDetaljaAutomobila)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (automobil == null)
            {
                return NotFound();
            }

            var Model = new AutomobiliDodajVM
            {
                Automobil = automobil,
                DetaljiKarakteristika = _context
                .DetaljiKarakteristika
                .ToList()
                .Select(x => new DetaljiKarakteristikaVM
                {
                    DetaljiKarakteristikaId = x.Id,
                    Naziv = x.Naziv,
                    Oznaceno = automobil.KarakteristikeDetaljaAutomobila.Any(y => y.DetaljiKarakteristikaId == x.Id)
                }).ToList()
            };

            ViewData["KategorijaID"] = new SelectList(_context.Kategorija, "Id", "Naziv", automobil.KategorijaID);
            ViewData["ProizvodjacID"] = new SelectList(_context.Proizvodjac, "Id", "Naziv");
            return View(Model);
        }

        // POST: Admin/Automobil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AutomobiliDodajVM VM)
        {
            if (id != VM.Automobil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(VM.Automobil);

                    if (VM.OznaceneKarakteristike == null)
                        VM.OznaceneKarakteristike = new List<int>();

                    var postojeceKarakteristike = _context.KarakteristikeDetaljaAutomobila.Where(x => x.AutomobilId == id).ToList();
                    foreach (var item in postojeceKarakteristike)
                    {
                        if (!VM.OznaceneKarakteristike.Contains(item.DetaljiKarakteristikaId))
                        {
                            _context.Remove(item);
                        }
                    }

                    foreach (int KarakteristikaId in VM.OznaceneKarakteristike)
                    {
                        var karakteristikaPostoji = _context.DetaljiKarakteristika.Find(KarakteristikaId);
                        if (karakteristikaPostoji != null && !postojeceKarakteristike.Any(x => x.DetaljiKarakteristikaId == KarakteristikaId))
                        {
                            var novaKarakteristika = new KarakteristikeDetaljaAutomobila
                            {
                                DetaljiKarakteristikaId = KarakteristikaId,
                                AutomobilId = VM.Automobil.Id
                            };
                            _context.KarakteristikeDetaljaAutomobila.Add(novaKarakteristika);

                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobilExists(VM.Automobil.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategorijaID"] = new SelectList(_context.Kategorija, "Id", "Naziv", VM.Automobil.KategorijaID);
            ViewData["ProizvodjacID"] = new SelectList(_context.Proizvodjac, "Id", "Naziv");
            return View(VM.Automobil);
        }

        // GET: Admin/Automobil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .Include(a => a.Kategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // POST: Admin/Automobil/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Obriši(int id)
        {
            var automobil = await _context.Automobil.FindAsync(id);
            _context.Automobil.Remove(automobil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomobilExists(int id)
        {
            return _context.Automobil.Any(e => e.Id == id);
        }
    }
}
