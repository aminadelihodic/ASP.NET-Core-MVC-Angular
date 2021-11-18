using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Novosti
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Sažetak { get; set; }
        public string Sadržaj { get; set; }
        public string Autor { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public string Slika { get; set; }
        public virtual ApplicationUser Korisnik { get; set; }
        public string ImagePath { get; set; }

    }
}
