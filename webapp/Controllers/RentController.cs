using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using rentacar.Data;
using rentacar.Models;
using rentacar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace rentacar.Controllers
{
    public class RentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewData["poruka"] = TempData["nesto"];
            return View();
        }
        public bool IsAvailable(int carId, DateTime fromDate, DateTime toDate)
        {
            var cars = _context.Rent.Where(s => s.AutomobilId == carId);
            foreach (var item in cars)
            {
                if (toDate > item.Od && toDate <= item.Do)
                {
                    return false;
                }
                if (fromDate >= item.Od && fromDate <= item.Do)
                {
                    return false;
                }
            }
            return true;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(IznajmljivanjeViewModel model)
        {
            if (model.ToDate > model.fromDate && model.fromDate >= DateTime.Now)
            {
                if (model.CarId != 0 && model.fromDate != new DateTime() && model.ToDate != new DateTime())
                {
                    if (IsAvailable(model.CarId, model.fromDate, model.ToDate))
                    {
                        Rent r = new Rent()
                        {
                            AutomobilId = model.CarId,
                            KorisnikId = _userManager.GetUserId(HttpContext.User),
                            Od = model.fromDate,
                            Do = model.ToDate,
                            Verifikovan = false
                        };
                        _context.Rent.Add(r);
                        await _context.SaveChangesAsync();
                        TempData["success"] = "success";
                    }
                    else
                    {
                        var s = _context.Rent.Where(s => s.AutomobilId == model.CarId).OrderByDescending(r => r.Do).FirstOrDefault();
                        var nextFree = s.Do.AddDays(1);
                        TempData["success"] = "Car is not available in that period. Date that car is free is: " + nextFree.ToShortDateString();
                    }
                }
            }
            else
            {
                TempData["success"] = "failed";
            }
            return RedirectToAction("Index", "User");
        }
        [Authorize]
        public IActionResult GetAll()
        {

            ViewData["AlreadyVerified"] = TempData["Message"];
            if (User.IsInRole("Admin"))
            {
                List<GetAllRentsViewModel> model = _context.Rent.Select(s => new GetAllRentsViewModel()
                {
                    FromDate = s.Od,
                    ToDate = s.Do,
                    IsVerified = s.Verifikovan,
                    RentId = s.Id,
                    User = _context.Users.FirstOrDefault(e => e.Id == s.KorisnikId).UserName,
                    Car = _context.Automobil.FirstOrDefault(r => r.Id == s.AutomobilId).Naziv
                }).ToList();

                return View(model);
            }
            ViewData["Message"] = "You don't have a permission!";
            return View("AuthError");
        }

        public async Task<IActionResult> VerifyAsync(int Id)
        {

            var rent = _context.Rent.FirstOrDefault(s => s.Id == Id);
            if (!rent.Verifikovan)
            {
                var car = _context.Automobil.FirstOrDefault(s => s.Id == rent.AutomobilId);
                float totalPrice = (rent.Do - rent.Od).Days * car.Cijena;
                Ugovor newContract = new Ugovor()
                {
                    Datum = DateTime.Now,
                    Opis = "",
                    RentId = Id,
                    FinalnaCijena = totalPrice,
                };
                rent.Verifikovan = true;
                _context.Rent.Update(rent);
                _context.Ugovor.Add(newContract);
                _context.SaveChanges();


                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("razvoj.softvera1@gmail.com", "razvojsoftvera11");
                SmtpServer.EnableSsl = true;

                string sendTo = _context.Users.FirstOrDefault(e => e.Id == rent.KorisnikId).Email;

                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(sendTo));

                mail.From = new MailAddress("razvoj.softvera1@gmail.com");  // replace with valid value;
                
                mail.Subject = "Mail sa stranice";
                mail.Body += " <html>";
                mail.Body += "<body>";
                mail.Body += "<h1>Your car is waiting for you.</h1><p>Your reservation is approved.";
                mail.Body += "</body>";
                mail.Body += "</html>";
                mail.IsBodyHtml = true;

                SmtpServer.Send(mail);
                return RedirectToAction("GetAll");
            }
            else
            {
                TempData["Message"] = "Already verified!";
                return RedirectToAction("GetAll");

            }
        }
    }
}
