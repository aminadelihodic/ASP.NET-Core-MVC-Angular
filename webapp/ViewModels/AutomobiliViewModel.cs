using rentacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.ViewModels
{
    public class AutomobiliViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        //[Range(0, 999.99)]
        public float Price { get; set; }
        public int KategorijaId { get; set; }
        public virtual Kategorija Kategorija { get; set; }
        public List<Slika> Slike { get; set; }

        public AutomobiliViewModel()
        {
            Slike = new List<Slika>();
        }
    }
}
