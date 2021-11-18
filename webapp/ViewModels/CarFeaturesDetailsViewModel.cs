using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.Models;

namespace rentacar.ViewModels
{
    public class CarFeaturesDetailsViewModel
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string Description { get; set; }
        public int ProfitAmount { get; set; }
        public float Price { get; set; }
        public List<DetaljiKarakteristika> Features { get; set; }
        public List<Slika> Pictures { get; set; }
        public Kategorija Category { get; set; }
        public string Manufacturer { get; internal set; }
    }
}
