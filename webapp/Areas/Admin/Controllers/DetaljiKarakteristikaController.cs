using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rentacar.Data;
using rentacar.Models;

namespace rentacar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DetaljiKarakteristikaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetaljiKarakteristikaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DetaljiKarakteristika
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetaljiKarakteristika.ToListAsync());
        }

        // GET: Admin/DetaljiKarakteristika/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DetaljiKarakteristika/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] DetaljiKarakteristika detaljiKarakteristika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detaljiKarakteristika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detaljiKarakteristika);
        }

        // GET: Admin/DetaljiKarakteristika/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detaljiKarakteristika = await _context.DetaljiKarakteristika.FindAsync(id);
            if (detaljiKarakteristika == null)
            {
                return NotFound();
            }
            return View(detaljiKarakteristika);
        }

        // POST: Admin/DetaljiKarakteristika/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] DetaljiKarakteristika detaljiKarakteristika)
        {
            if (id != detaljiKarakteristika.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detaljiKarakteristika);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetaljiKarakteristikaExists(detaljiKarakteristika.Id))
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
            return View(detaljiKarakteristika);
        }

        // GET: Admin/DetaljiKarakteristika/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detaljiKarakteristika = await _context.DetaljiKarakteristika
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detaljiKarakteristika == null)
            {
                return NotFound();
            }

            return View(detaljiKarakteristika);
        }

        // POST: Admin/DetaljiKarakteristika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detaljiKarakteristika = await _context.DetaljiKarakteristika.FindAsync(id);
            _context.DetaljiKarakteristika.Remove(detaljiKarakteristika);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetaljiKarakteristikaExists(int id)
        {
            return _context.DetaljiKarakteristika.Any(e => e.Id == id);
        }
    }
}
