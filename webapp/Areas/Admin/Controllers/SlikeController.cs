using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rentacar.Data;
using rentacar.Models;
using rentacar.Services;

namespace rentacar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlikeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlikeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Slike
        public async Task<IActionResult> Index(int Id)
        {
            var applicationDbContext = _context.Slika.Where(x => x.AutomobilId == Id);
            ViewBag.AutomobilId = Id;

            return PartialView(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Slike/Create
        public IActionResult Create(int Id)
        {
            Slika slika = new() { AutomobilId = Id };
            return PartialView(slika);
        }

        // POST: Admin/Slike/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutomobilId")] Slika slika, IFormFile SlikaUpload)
        {
            if (ModelState.IsValid && SlikaUpload != null)
            {
                _context.Add(slika);

                string fileName = FileUploadHelper.SaveUploadedFile(SlikaUpload);
                slika.Url = "Uploads/" + fileName;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { Id = slika.AutomobilId });
            }
            return PartialView(slika);
        }

        // GET: Admin/Slike/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slika = await _context.Slika.FindAsync(id);
            if (slika == null)
            {
                return NotFound();
            }
            return PartialView(slika);
        }

        // POST: Admin/Slike/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Slika slika, IFormFile SlikaUpload)
        {
            if (id != slika.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var staraSlika = _context.Slika.Find(id);

                try
                {
                    var staraSlikaPath = "wwwroot/" + staraSlika.Url;
                    if (System.IO.File.Exists(staraSlikaPath))
                    {
                        System.IO.File.Delete(staraSlikaPath);
                    }

                    string fileName = FileUploadHelper.SaveUploadedFile(SlikaUpload);
                    staraSlika.Url = "Uploads/" + fileName;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlikaExists(slika.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { Id = staraSlika.AutomobilId });
            }
            return PartialView(slika);
        }

        // GET: Admin/Slike/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slika = await _context.Slika
                .Include(s => s.Automobil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slika == null)
            {
                return NotFound();
            }

            return PartialView(slika);
        }

        // POST: Admin/Slike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slika = await _context.Slika.FindAsync(id);
            _context.Slika.Remove(slika);
            await _context.SaveChangesAsync();

            var slikaPath = "wwwroot/" + slika.Url;
            if (System.IO.File.Exists(slikaPath))
            {
                System.IO.File.Delete(slikaPath);
            }


            return RedirectToAction(nameof(Index), new { Id = slika.AutomobilId });
        }

        private bool SlikaExists(int id)
        {
            return _context.Slika.Any(e => e.Id == id);
        }
    }
}
