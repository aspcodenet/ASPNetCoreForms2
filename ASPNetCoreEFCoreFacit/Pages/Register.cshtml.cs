using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNetCoreEFCoreFacit.Pages
{
    public class RegisterModel : PageModel
    {
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/RegisterConfirmation",new {
                    firstname = First
                });
            }

            return Page();
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public bool OkUpdates { get; set; }

        [BindProperty]
        [MaxLength(100)]
        public string Password { get; set; }

        [BindProperty]
        [MaxLength(100)]
        public string Last { get; set; }

        [BindProperty]
        [MaxLength(100)]
        public string First { get; set; }

        [BindProperty]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
