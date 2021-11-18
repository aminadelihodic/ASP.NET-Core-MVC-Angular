using rentacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.ViewModels
{
    public class CarCommentViewModel
    {
        public string Title { get; set; }
        public List<KomentariAutomobila> ListOfComments { get; set; }
        public string Comment { get; set; }
        public int CarId { get; set; }
        public int Rating { get; set; }

        public CarFeaturesDetailsViewModel CarFeatures { get; set; }
        public CarCommentViewModel()
        {
            CarFeatures = new CarFeaturesDetailsViewModel();
        }
    }
}