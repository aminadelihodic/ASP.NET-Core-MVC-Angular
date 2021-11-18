using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using rentacar.Areas.Admin.ViewModels;
using rentacar.Data;
using rentacar.Models;

namespace rentacar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class KorisniciController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public KorisniciController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // GET: Admin/Korisnici
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }


        // GET: Admin/Korisnici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Korisnici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KorisniciCreateVM korisnik)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = korisnik.Email, Email = korisnik.Email, Ime = korisnik.Ime, Prezime = korisnik.Prezime, Telefon = korisnik.Telefon };
                var result = await _userManager.CreateAsync(user, korisnik.Lozinka);
                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "Klijent");
                    if (!roleResult.Succeeded)
                    {
                        ModelState.AddModelError("", "Cannot add selected roles to user");
                        return View(korisnik);
                    }

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = Url.Content("~/") },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(korisnik.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(korisnik);
        }

        // GET: Admin/Korisnici/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Users.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            var model = new KorisniciEditVM
            {
                Id = korisnik.Id,
                Email = korisnik.Email,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Telefon = korisnik.Telefon
            };
            return View(model);
        }

        // POST: Admin/Korisnici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, KorisniciEditVM korisnik)
        {
            if (id != korisnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var postojeciKorisnik = _context.Users.Find(id);
                    if (postojeciKorisnik != null)
                    {
                        postojeciKorisnik.Ime = korisnik.Ime;
                        postojeciKorisnik.Prezime = korisnik.Prezime;
                        postojeciKorisnik.Email = korisnik.Email;
                        postojeciKorisnik.UserName = korisnik.Email;
                        postojeciKorisnik.Telefon = korisnik.Telefon;
                        if (!string.IsNullOrEmpty(korisnik.Lozinka))
                        {
                            var newPasswordHash = _userManager.PasswordHasher.HashPassword(postojeciKorisnik, korisnik.Lozinka);
                            postojeciKorisnik.PasswordHash = newPasswordHash;
                        }

                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorisnikExists(korisnik.Id))
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
            return View(korisnik);
        }

        // GET: Admin/Korisnici/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // POST: Admin/Korisnici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var korisnik = await _context.Users.FindAsync(id);
            _context.Users.Remove(korisnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KorisnikExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
