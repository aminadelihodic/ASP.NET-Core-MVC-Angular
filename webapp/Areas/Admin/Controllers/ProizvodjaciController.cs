using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rentacar.Data;
using rentacar.Models;

namespace rentacar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProizvodjaciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProizvodjaciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Proizvodjaci
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proizvodjac.ToListAsync());
        }

        // GET: Admin/Proizvodjaci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjac
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return View(proizvodjac);
        }

        // GET: Admin/Proizvodjaci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Proizvodjaci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] Proizvodjac proizvodjac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvodjac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proizvodjac);
        }

        // GET: Admin/Proizvodjaci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjac.FindAsync(id);
            if (proizvodjac == null)
            {
                return NotFound();
            }
            return View(proizvodjac);
        }

        // POST: Admin/Proizvodjaci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] Proizvodjac proizvodjac)
        {
            if (id != proizvodjac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvodjac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvodjacExists(proizvodjac.Id))
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
            return View(proizvodjac);
        }

        // GET: Admin/Proizvodjaci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjac
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return View(proizvodjac);
        }

        // POST: Admin/Proizvodjaci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvodjac = await _context.Proizvodjac.FindAsync(id);
            _context.Proizvodjac.Remove(proizvodjac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvodjacExists(int id)
        {
            return _context.Proizvodjac.Any(e => e.Id == id);
        }
    }
}
