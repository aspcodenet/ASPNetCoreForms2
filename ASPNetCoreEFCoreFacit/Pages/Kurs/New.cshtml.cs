using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreEFCoreFacit.Data;
using ASPNetCoreEFCoreFacit.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNetCoreEFCoreFacit.Pages.Kurs
{
    public class NewModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageProvider _imageProvider;

        [BindProperty]
        [MaxLength(100)]
        public string Namn { get; set; }

        [BindProperty]
        [MaxLength(512)]
        public string Beskrivning { get; set; }


        [BindProperty]
        [Required]
        public int SelectDayOfWeek { get; set; }
        public List<SelectListItem> AllDayOfWeeks { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime StartDay { get; set; } // Date

        [BindProperty]
        public IFormFile Bild { get; set; }
        

        public NewModel(ApplicationDbContext context, IImageProvider imageProvider)
        {
            _context = context;
            _imageProvider = imageProvider;
        }


        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var d = new Data.Kurs();
                _context.Kurser.Add(d);
                d.Namn = Namn;
                d.Beskrivning = Beskrivning;
                d.StartDay = StartDay;
                d.DayOfWeek = (DayOfWeek)SelectDayOfWeek;
                d.LastModified = DateTime.UtcNow;
                d.Created = DateTime.UtcNow;
                _context.SaveChanges();

                if (Bild.Length > 0)
                {
                    var path = _imageProvider.GetSavingPathFor(d.Id, Bild.FileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        Bild.CopyTo(fileStream);
                    }
                }

                
                return RedirectToPage("Lista");
            }
            SetAllDayOfWeeks();
            return Page();

        }


        public void OnGet()
        {
            SelectDayOfWeek = -1;
            SetAllDayOfWeeks();
        }

        private void SetAllDayOfWeeks()
        {
            AllDayOfWeeks = Enum.GetValues<DayOfWeek>().Cast<DayOfWeek>()
                .Select(e => new SelectListItem(e.ToString(), ((int)e).ToString())).ToList();

            AllDayOfWeeks.Insert(0, new SelectListItem("...välj dag...", "-1"));
        }

    }
}
