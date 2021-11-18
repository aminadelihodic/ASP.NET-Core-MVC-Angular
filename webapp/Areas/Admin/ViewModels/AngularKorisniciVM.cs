using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Areas.Admin.ViewModels
{
    public class AngularKorisniciVM
    {
        public string Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Uloga { get; set; }
        public string Telefon { get; set; }
        public string SlikaProfilaUrl { get; set; }
    }
}
