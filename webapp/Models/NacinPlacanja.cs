using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class NacinPlacanja
    {
        public int Id { get; set; }
        public int? BrojKartice { get; set; }
        public int? Ostalo { get; set; }
        public int KorisnikId { get; set; }
    }
}
