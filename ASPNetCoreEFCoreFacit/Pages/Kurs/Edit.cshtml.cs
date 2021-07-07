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
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreEFCoreFacit.Pages.Kurs
{
    public class EditModel : PageModel
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
        public IFormFile Bild { get; set; }


        public string BildSrc { get; set; }

        [BindProperty]
        [Required]
        public int SelectDayOfWeek { get; set; }
        public List<SelectListItem> AllDayOfWeeks { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime StartDay { get; set; } // Date

        public EditModel(ApplicationDbContext context, IImageProvider imageProvider)
        {
            _context = context;
            _imageProvider = imageProvider;
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var d = _context.Kurser.First(e => e.Id == id);
                d.Namn = Namn;
                d.Beskrivning = Beskrivning;
                d.StartDay = StartDay;
                d.DayOfWeek = (DayOfWeek) SelectDayOfWeek;
                d.LastModified = DateTime.UtcNow;
                if (Bild.Length > 0)
                {
                    RemoveExistingImages(d.Id);
                    SaveImage(d.Id);
                }
                _context.SaveChanges();
                return RedirectToPage("Lista");
            }
            SetAllDayOfWeeks();
            return Page();

        }

        private void SaveImage(int id)
        {
            var path = _imageProvider.GetSavingPathFor(id, Bild.FileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                Bild.CopyTo(fileStream);
            }

        }

        private void RemoveExistingImages(int itemId)
        {
            _imageProvider.RemoveExistingImages(itemId);
        }

        public void OnGet(int id)
        {
            var d = _context.Kurser.First(e => e.Id == id);
            Namn = d.Namn;
            Beskrivning = d.Beskrivning;
            StartDay = d.StartDay;
            SelectDayOfWeek = (int)d.DayOfWeek;
            BildSrc = GetBildSource(d.Id, d.LastModified);

            SetAllDayOfWeeks();
        }

        private void SetAllDayOfWeeks()
        {
            AllDayOfWeeks = Enum.GetValues<DayOfWeek>().Cast<DayOfWeek>()
                .Select(e => new SelectListItem(e.ToString(), ((int) e).ToString())).ToList();

            AllDayOfWeeks.Insert(0, new SelectListItem("...välj dag...",""));
        }



        private string GetBildSource(int itemId, DateTime lastModified)
        {
            return _imageProvider.GetBildSource(itemId, lastModified);
        }

    }
}
