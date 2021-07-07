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
    public class BilarModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<BilListViewModel> Bilar { get; set; }

        public class BilListViewModel
        {
            public int Id { get; set; }
            public string Regno { get; set; }
            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public decimal Price { get; set; }
        }

        public BilarModel(ApplicationDbContext context)
        {
            _context = context;
        }


        public void OnGet(string q)
        {
            Bilar = _context.Bilar.Select(r => new BilListViewModel
            {
                Id = r.Id,
                Manufacturer = r.Manufacturer.Namn,
                Model = r.Model,
                Price = r.Price,
                Regno = r.RegNo
            }).Where(e=> string.IsNullOrEmpty(q) || e.Regno.Contains(q)).ToList();
        }
    }
}
