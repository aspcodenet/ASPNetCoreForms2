using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreEFCoreFacit.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreEFCoreFacit.Pages
{
    public class CVModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public CVModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var n = new CV();
                n.Namn = Namn;
                n.Adress = Adress;
                n.Bil = Bil;
                n.Email = Email;
                n.Korkort = Korkort;
                n.Mobil = Mobil;
                n.Postnr = Postnr;
                n.Postort = Postort;
                n.PossibleWorkLocation = Enum.Parse<PossibleWorkLocation>(SelectedWorklocation);
                n.Utbildningar = _dbContext.Utbildningar.Where(r => SelectedEducationIds.Contains(r.Id)).ToList();
                _dbContext.CVs.Add(n);
                _dbContext.SaveChanges();
                return RedirectToPage("/RegisterConfirmation");

            }
            Worklocations = Enum.GetValues<PossibleWorkLocation>()
                .Cast<PossibleWorkLocation>().Select(r => r.ToString()).ToList();

            AllEducations = _dbContext.Utbildningar.Select(r => new SelectListItem
            {
                Text = r.Namn,
                Value = r.Id.ToString()
            }).ToList();
            return Page();
        }

        public void OnGet()
        {
            Worklocations = Enum.GetValues<PossibleWorkLocation>()
                .Cast<PossibleWorkLocation>().Select(r => r.ToString()).ToList();

            AllEducations = _dbContext.Utbildningar.Select(r => new SelectListItem
            {
                Text = r.Namn,
                Value = r.Id.ToString()
            }).ToList();
        }

        [BindProperty]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [BindProperty]
        public bool Bil { get; set; }
        [BindProperty]
        public bool Korkort { get; set; }
        [MaxLength(50)]
        [BindProperty]
        public string Postort { get; set; }

        [BindProperty]
        [MaxLength(10)]
        public string Postnr { get; set; }

        [BindProperty]
        [MaxLength(100)]
        public string Adress { get; set; }

        [BindProperty]
        [MaxLength(20)]

        public string Mobil { get; set; }
        [BindProperty]
        [MaxLength(50)]
        public string Namn { get; set; }

        [BindProperty]
        public string SelectedWorklocation { get; set; }
        public List<string> Worklocations { get; set; }


        [BindProperty] public List<int> SelectedEducationIds { get; set; } = new List<int>();


        public List<SelectListItem> AllEducations { get; set; }

    }
}
