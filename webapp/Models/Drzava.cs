using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Drzava
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public virtual ICollection<Grad> Gradovi { get; set; }
    }
}
