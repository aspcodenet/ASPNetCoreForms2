using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreEFCoreFacit.Data;
using ASPNetCoreEFCoreFacit.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNetCoreEFCoreFacit.Pages.Kurs
{
    public class ListaModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageProvider _imageProvider;

        public List<KursItem> Items { get; set; }

        public class KursItem
        {
            public int Id { get; set; }
            public string Namn { get; set; }
            public string BildSrc { get; set; }

            public DateTime LastModified { get; set; }
        }

        public ListaModel(ApplicationDbContext context, IImageProvider imageProvider)
        {
            _context = context;
            _imageProvider = imageProvider;
        }
        public void OnGet()
        {
            Items = _context.Kurser.Select(r => new KursItem
            {
                Id = r.Id,
                Namn = r.Namn,
                LastModified = r.LastModified
            }).ToList();

            foreach (var item in Items)
                item.BildSrc = GetBildSource(item.Id, item.LastModified);
        }

        private string GetBildSource(int itemId, DateTime lastModified)
        {
            return _imageProvider.GetBildSource(itemId, lastModified);
        }
    }
}
