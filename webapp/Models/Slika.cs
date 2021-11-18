using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Slika
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int AutomobilId { get; set; }
        public Automobil Automobil { get; set; }
    }
}
