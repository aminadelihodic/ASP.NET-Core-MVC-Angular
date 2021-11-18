using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Ugovor
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Opis { get; set; }
        public float FinalnaCijena { get; set; }
        public int? RentId { get; set; }
        public int? AutomobilId { get; set; }
        public virtual Rent Rent { get; set; }
        public virtual Automobil Automobil { get; set; }
    }
}
