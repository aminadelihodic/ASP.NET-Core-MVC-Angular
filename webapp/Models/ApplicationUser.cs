using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        [Display(Name = "Profilna slika")]
        public string SlikaProfilaUrl { get; set; }
        public bool Deaktiviran { get; set; }
    }
}
