using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class KarakteristikeDetaljaAutomobila
    {
        public int Id { get; set; }
        public int AutomobilId { get; set; }
        public Automobil Automobil { get; set; }
        public int DetaljiKarakteristikaId { get; set; }
        public DetaljiKarakteristika DetaljiKarakteristika { get; set; }
    }
}
