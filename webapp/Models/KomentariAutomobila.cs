using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class KomentariAutomobila
    {
        public int Id { get; set; }
        public string Komentar { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int AutomobilId { get; set; }
        public Automobil Automobil { get; set; }
        public int Ocjena { get; set; }
        public virtual ApplicationUser Korisnik { get; set; }
    }
}
