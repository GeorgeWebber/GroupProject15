using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupProject15.Pages
{
    public class PositiveFormSuccessModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Case Name"] = HttpContext.Session.GetString("Case Name");
        }
    }
}
