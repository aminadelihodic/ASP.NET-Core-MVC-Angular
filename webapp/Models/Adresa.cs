using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Adresa
    {
        public int AdresaId { get; set; }
        public string Naziv { get; set; }
        public int Broj { get; set; }
        public virtual Grad Grad { get; set; }
    }
}
