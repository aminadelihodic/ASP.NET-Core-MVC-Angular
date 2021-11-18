using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Kategorija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public virtual ICollection<Automobil> Automobili { get; set; }
    }
}
