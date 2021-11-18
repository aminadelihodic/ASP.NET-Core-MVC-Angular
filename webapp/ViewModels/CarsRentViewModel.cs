using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.ViewModels
{
    public class CarsRentViewModel
    {
        public IEnumerable<AutomobiliViewModel> Automobili { get; set; }
        public IznajmljivanjeViewModel Iznajmljivanje { get; set; }

        public CarsRentViewModel()
        {
            Automobili = new List<AutomobiliViewModel>();
        }
    }
}
