using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rentacar.Data;
using rentacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Controllers
{
    public class WishListController : Controller
    {
        private UserManager<rentacar.Models.ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public WishListController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var list = _context.Wishlist.Where(x => x.KorisnikId.Equals(user.Id)).Include(c => c.Automobil).Include(u => u.Korisnik).ToList();

                return View(list);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AddItem(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            var imamUBazi = _context.Wishlist.Where(x => x.KorisnikId.Equals(user.Id) && x.AutomobilId == id).FirstOrDefault();

            if (user != null && imamUBazi == null)
            {
                Wishlist whishList = new Wishlist();

                whishList.AutomobilId = id;
                whishList.KorisnikId = user.Id;


                _context.Wishlist.Add(whishList);
                _context.SaveChanges();

                return Json(true);
            }

            return Json(false);
        }
    }
}
