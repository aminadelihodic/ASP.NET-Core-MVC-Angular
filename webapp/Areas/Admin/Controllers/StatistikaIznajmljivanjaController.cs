using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rentacar.Areas.Admin.ViewModels;
using rentacar.Data;
using rentacar.Models;

namespace rentacar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StatistikaIznajmljivanjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatistikaIznajmljivanjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/StatistikaIznajmljivanjaController
        public IActionResult Index(StatistikaIznajmljivanjaVM VM)
        {
            VM.GodineList = _context.Ugovor.GroupBy(x => x.Datum.Year).Select(x => new SelectListItem
            {
                Text = x.Key.ToString(),
                Value = x.Key.ToString()
            }).ToList();

            if (VM.Godina == 0)
                VM.Godina = DateTime.Now.Year;

            VM.MjeseciList = new List<string>();
            VM.Statistika = new List<AutomobilStatistikaGrupisanoVM>();

            var AutomobiliList = _context.Automobil.ToList();

            for (int i = 1; i <= 12; i++)
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i);
                VM.MjeseciList.Add(monthName);

                foreach (var automobil in AutomobiliList)
                {
                    int BrojIznajmljivanja = _context.Ugovor
                        .Where(x => x.Datum.Year == VM.Godina)
                        .Where(x => x.Datum.Month == i && x.AutomobilId.Value == automobil.Id)
                        .Count();

                    var postojecaStatistika = VM.Statistika.Where(x => x.NazivAutomobila == automobil.Naziv).FirstOrDefault();
                    if(postojecaStatistika != null)
                    {
                        postojecaStatistika.BrojIznajmljivanjaByMonth.Add(BrojIznajmljivanja);
                    }
                    else
                    {
                        VM.Statistika.Add(new AutomobilStatistikaGrupisanoVM
                        {
                            NazivAutomobila = _context.Automobil.Find(automobil.Id).Naziv,
                            BrojIznajmljivanjaByMonth = new List<int> { BrojIznajmljivanja }
                        });
                    }
                    
                }
            }

            return View(VM);
        }


    }
}
