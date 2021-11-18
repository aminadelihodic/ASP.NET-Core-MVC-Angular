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
    public class AngularKorisniciController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IEmailSender _emailSender;

        public AngularKorisniciController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // GET: Admin/Korisnici
        public async Task<JsonResult> Index(string uloga, string pretraga)
        {
            var list = await _context.Users
                .Where(x => pretraga == null || (x.Ime + " " + x.Prezime).ToLower().Contains(pretraga.ToLower()))
                .Where(x => !x.Deaktiviran)
                .ToListAsync();

            var result = new List<AngularKorisniciVM>();
            foreach (var item in list)
            {
                var korisnik = new AngularKorisniciVM
                {
                    Id = item.Id,
                    Ime = item.Ime,
                    Telefon = item.Telefon,
                    Email = item.Email,
                    Prezime = item.Prezime,
                    SlikaProfilaUrl = item.SlikaProfilaUrl,
                    UserName = item.UserName
                };

                if (await _userManager.IsInRoleAsync(item, "Admin"))
                {
                    korisnik.Uloga = "Admin";
                }
                if (await _userManager.IsInRoleAsync(item, "Klijent"))
                {
                    korisnik.Uloga = "Klijent";
                }

                if (uloga == null || uloga == korisnik.Uloga)
                    result.Add(korisnik);
            }

            return Json(result);
        }

        // POST: Admin/Korisnici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]KorisniciCreateVM korisnik)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = korisnik.Email, Email = korisnik.Email, Ime = korisnik.Ime, Prezime = korisnik.Prezime, Telefon = korisnik.Telefon };
                var result = await _userManager.CreateAsync(user, korisnik.Lozinka);
                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, korisnik.Uloga);
                    if (!roleResult.Succeeded)
                    {
                        ModelState.AddModelError("", "Cannot add selected roles to user");
                        return BadRequest(ModelState.Values);
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

                    return Ok();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return BadRequest(ModelState.Values);
        }


        // GET: Admin/Korisnici/Delete/5
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var korisnik = await _context.Users.FindAsync(id);
            korisnik.Deaktiviran = true;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
