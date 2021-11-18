using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Wishlist
    {
        public int Id { get; set; }
        public int AutomobilId { get; set; }
        public string KorisnikId { get; set; }
        public virtual Automobil Automobil { get; set; }
        public virtual ApplicationUser Korisnik { get; set; }
    }
}
