using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNetCoreEFCoreFacit.Pages
{
    public class MultilineInputModel : PageModel
    {
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/MultilineInputThanks");
            }
            return Page();
        }

        public void OnGet()
        {
        }

        [BindProperty]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [BindProperty]
        [MaxLength(512)]
        public string Question { get; set; }
    }
}
