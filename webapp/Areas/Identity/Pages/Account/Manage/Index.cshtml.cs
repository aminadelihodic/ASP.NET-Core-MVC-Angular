using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rentacar.Data;
using rentacar.Models;
using rentacar.Services;

namespace rentacar.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment Environment;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            Environment = environment;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Broj telefona")]
            public string PhoneNumber { get; set; }
            [Required]
            public string Ime { get; set; }
            [Required]
            public string Prezime { get; set; }
            public string SlikaProfilaUrl { get; set; }
            public string Uloga { get; set; }
        }

        [BindProperty]
        public IFormFile SlikaUpload { get; set; }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            Username = userName;

            Input = new InputModel
            {
                Ime = user.Ime,
                Prezime = user.Prezime,
                PhoneNumber = user.Telefon,
                SlikaProfilaUrl = user.SlikaProfilaUrl,
                Uloga = roles.Count > 0 ? roles[0] : null
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            user.Ime = Input.Ime;
            user.Prezime = Input.Prezime;
            user.Telefon = Input.PhoneNumber;

            if (SlikaUpload != null)
            {
                if (user.SlikaProfilaUrl != null)
                {
                    FileUploadHelper.DeleteUploadedFile(user.SlikaProfilaUrl);
                }

                string fileName = FileUploadHelper.SaveUploadedFile(SlikaUpload);

                user.SlikaProfilaUrl = "Uploads/" + fileName;
            }

            await _context.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
