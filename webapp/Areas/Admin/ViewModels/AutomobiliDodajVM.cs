using rentacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Areas.Admin.ViewModels
{
    public class AutomobiliDodajVM
    {
        public Automobil Automobil { get; set; }
        public List<DetaljiKarakteristikaVM> DetaljiKarakteristika { get; set; }

        public List<int> OznaceneKarakteristike { get; set; }
    }
}
