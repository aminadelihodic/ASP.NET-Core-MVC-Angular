using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rentacar.Areas.Admin.ViewModels;
using rentacar.Data;
using rentacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AngularProizvodjaciController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public AngularProizvodjaciController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        // GET: Admin/Proizvodjaci
        
        public async Task<JsonResult> Index(string pretraga)
        {
            var list = await _context.Proizvodjac
                .Where(x => pretraga == null || (x.Naziv).ToLower().Contains(pretraga.ToLower())).ToListAsync();
                

            var result = new List<AngularProizvodjaciVM>();
            foreach (var item in list)
            {
                var proizvodjac = new AngularProizvodjaciVM
                {
                    Id = (item.Id).ToString(),
                    Naziv = item.Naziv,
                    
                };
                result.Add(proizvodjac);

                
            }

            return Json(result);
        }

        // POST: Admin/Korisnici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Proizvodjac proizvodjac)
        {
            if (ModelState.IsValid)
            {
                var novi = new Proizvodjac { Naziv = proizvodjac.Naziv };
                _context.Proizvodjac.Add(novi);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState.Values);
        }


        // GET: Admin/Korisnici/Delete/5
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var korisnik = await _context.Proizvodjac.FindAsync(id);
            //korisnik.Deaktiviran = true;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}