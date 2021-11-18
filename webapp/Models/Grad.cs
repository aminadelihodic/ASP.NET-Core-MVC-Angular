using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Grad
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public int PostanskiBroj { get; set; }
        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Adresa> Adrese { get; set; }
    }
}
