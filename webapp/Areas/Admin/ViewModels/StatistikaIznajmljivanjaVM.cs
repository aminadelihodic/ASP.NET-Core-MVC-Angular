using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Areas.Admin.ViewModels
{
    public class StatistikaIznajmljivanjaVM
    {
        public List<string> MjeseciList { get; set; }
        public List<AutomobilStatistikaGrupisanoVM> Statistika { get; set; }

        public int Godina { get; set; }
        public List<SelectListItem> GodineList { get; set; }
    }

    public class AutomobilStatistikaGrupisanoVM
    {
        public string NazivAutomobila { get; set; }
        public List<int> BrojIznajmljivanjaByMonth { get; set; }
    }

    public class AutomobilStatistikaQueryVM
    {
        public int Mjesec { get; set; }
        public int BrojIznajmljivanja { get; set; }
        public int? AutomobilId { get; set; }
    }
}