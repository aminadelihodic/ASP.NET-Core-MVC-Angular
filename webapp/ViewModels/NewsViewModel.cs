using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.ViewModels
{
    public class NewsViewModel
    {
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public IFormFile Slika { get; set; }
        public string ImagePath { get; set; }
    }
}
