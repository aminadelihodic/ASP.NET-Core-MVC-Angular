using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Areas.Admin.ViewModels
{
    public class IzvjestajVM
    {
        public List<string> Labels { get; set; }
        public List<string> Zarada { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DatumOd { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DatumDo { get; set; }
    }

    public class IzvjestajZaradaVM
    {
        public DateTime Datum { get; set; }
        public float Zarada { get; set; }
    }
}
