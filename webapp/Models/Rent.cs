using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public bool Verifikovan { get; set; }
        public string KorisnikId { get; set; }
        public ApplicationUser Korisnik { get; set; }
        public int AutomobilId { get; set; }
        public Automobil Automobil { get; set; }
    }
}
