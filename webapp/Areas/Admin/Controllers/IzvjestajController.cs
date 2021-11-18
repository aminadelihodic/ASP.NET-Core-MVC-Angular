using System;
using System.Collections.Generic;
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
    public class IzvjestajController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IzvjestajController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Izvjestaj
        public IActionResult Index(IzvjestajVM VM)
        {
            VM.DatumOd ??= DateTime.Today.AddDays(-10);
            VM.DatumDo ??= DateTime.Today;

            var zarada = _context.Ugovor
                .Where(x => x.Datum.Date >= VM.DatumOd.Value)
                .Where(x => x.Datum.Date <= VM.DatumDo.Value)
                .ToList()
                .GroupBy(x => x.Datum.Date)
                .Select(x => new IzvjestajZaradaVM
                {
                    Datum = x.Key,
                    Zarada = x.Sum(y => y.FinalnaCijena)
                })
                .ToList();

            DateTime TrenutniDatum = VM.DatumOd.Value;
            DateTime ZadnjiDatum = VM.DatumDo.Value;
            VM.Labels = new List<string>();
            VM.Zarada = new List<string>();

            while(TrenutniDatum <= ZadnjiDatum)
            {
                VM.Labels.Add(TrenutniDatum.ToString("dd.MM.yyyy"));

                var zarada_danas = zarada.Where(x => x.Datum == TrenutniDatum).FirstOrDefault();
                if(zarada_danas == null)
                {
                    VM.Zarada.Add("0.00");
                }
                else
                {
                    VM.Zarada.Add(zarada_danas.Zarada.ToString("0.00").Replace(',', '.'));
                }

                TrenutniDatum = TrenutniDatum.AddDays(1);
            }

            return View(VM);
        }

       
    }
}
