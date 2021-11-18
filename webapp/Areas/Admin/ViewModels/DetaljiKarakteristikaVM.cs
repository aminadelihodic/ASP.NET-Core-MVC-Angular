using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Areas.Admin.ViewModels
{
    public class DetaljiKarakteristikaVM
    {
        public int DetaljiKarakteristikaId { get; set; }
        public string Naziv { get; set; }
        public bool Oznaceno { get; set; }
    }
}
