using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class Automobil
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        [DisplayName("Iznos zarade")]
        public int IznosZarade { get; set; }
        public float Cijena { get; set; }
        [DisplayName("Kategorija")]
        public int KategorijaID { get; set; }
        public Kategorija Kategorija { get; set; }
        [DisplayName("Proizvođač")]
        public int ProizvodjacID { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
        public ICollection<KomentariAutomobila> KomentariAutomobila { get; set; }
        public ICollection<KarakteristikeDetaljaAutomobila> KarakteristikeDetaljaAutomobila { get; set; }
        public ICollection<Slika> Slike { get; set; }
    }
}
