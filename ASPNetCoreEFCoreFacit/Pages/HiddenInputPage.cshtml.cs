using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNetCoreEFCoreFacit.Pages
{
    public class HiddenInputPageModel : PageModel
    {
        public void OnPost()
        {
            Count++;

        }

        public void OnGet()
        {
            Count = 0;
        }

        [BindProperty]
        [HiddenInput]
        public int Count { get; set; }
    }
}
