using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreEFCoreFacit.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreEFCoreFacit.Pages
{
    public class BilModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public string Regno { get; set; }
        public string Manufacturer { get; set; }
        public string Modell { get; set; }
        public decimal Price { get; set; }
        public bool HasRadio { get; set; }

        public BilModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            var b = _context.Bilar.Include(e=>e.Manufacturer).First(r => r.Id == id);
            Regno = b.RegNo;
            Manufacturer = b.Manufacturer.Namn;
            Modell = b.Model;
            Price = b.Price;
            HasRadio = b.HasRadio;
        }
    }
}
