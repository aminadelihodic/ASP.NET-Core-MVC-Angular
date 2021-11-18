using Microsoft.AspNetCore.Mvc;
using rentacar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.ViewModels;
using rentacar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace rentacar.Controllers
{
    public class KomentariAutomobilaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public KomentariAutomobilaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CarComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KomentariAutomobila.Include(c => c.Automobil);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Add(CarCommentViewModel vm)
        {
            var comments = vm.Comment;
            var carId = vm.CarId;
            var rating = vm.Rating;

            KomentariAutomobila carComments = new KomentariAutomobila()
            {
                AutomobilId = carId,
                Komentar = comments,
                Ocjena = rating,
                DatumIzdavanja = DateTime.Now,
                Korisnik = await _userManager.GetUserAsync(User)
            };

            _context.KomentariAutomobila.Add(carComments);
            _context.SaveChanges();

            return RedirectToAction("Detalji", "Automobili", new { Id = carId });
        }

        // GET: CarComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carComments = await _context.KomentariAutomobila
                .Include(c => c.Automobil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carComments == null)
            {
                return NotFound();
            }

            return View(carComments);
        }

        // GET: CarComments/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Automobil, "Id", "Id");
            return View();
        }

        // POST: CarComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Komentar,DatumIzdavanja,AutomobilId,Ocjena")] KomentariAutomobila carComments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carComments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Automobil, "Id", "Id", carComments.AutomobilId);
            return View(carComments);
        }

        // GET: CarComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carComments = await _context.KomentariAutomobila.FindAsync(id);
            if (carComments == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Automobil, "Id", "Id", carComments.AutomobilId);
            return View(carComments);
        }

        // POST: CarComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Komentar,DatumIzdavanja,AutomobilId,Ocjena")] KomentariAutomobila carComments)
        {
            if (id != carComments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarCommentsExists(carComments.Id))
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
            ViewData["CarId"] = new SelectList(_context.Automobil, "Id", "Id", carComments.AutomobilId);
            return View(carComments);
        }

        // GET: CarComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carComments = await _context.KomentariAutomobila
                .Include(c => c.Automobil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carComments == null)
            {
                return NotFound();
            }

            return View(carComments);
        }

        // POST: CarComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carComments = await _context.KomentariAutomobila.FindAsync(id);
            _context.KomentariAutomobila.Remove(carComments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarCommentsExists(int id)
        {
            return _context.KomentariAutomobila.Any(e => e.Id == id);
        }
    }
}
