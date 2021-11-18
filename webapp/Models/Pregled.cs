using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Pregled
    {
        public int Id { get; set; }
        public int Ocjena { get; set; }
        public string Opis { get; set; }
        public virtual Automobil Automobil { get; set; }
    }
}
