using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Areas.Admin.ViewModels
{
    public class KorisniciEditVM
    {
        public string Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        [MinLength(4)]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }
        [DataType(DataType.Password)]
        [Compare("Lozinka")]
        [Display(Name="Potvrda lozinke")]
        public string LozinkaPotvrda { get; set; }
    }
}
