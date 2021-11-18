using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Services
{
    public static class CijenaHelper
    {
        public static string Valuta = "KM";
        public static string Formatiraj(float cijena)
        {
            return cijena.ToString("0.00") + " " + Valuta;
        }
    }
}
