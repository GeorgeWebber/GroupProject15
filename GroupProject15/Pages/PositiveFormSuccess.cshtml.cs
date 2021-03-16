using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupProject15.Pages
{
    public class PositiveFormSuccessModel : PageModel
    {
        public void OnGet(string forename, string lastname)
        {
            ForenameCheck = forename;
            LastNameCheck = lastname;
            Console.WriteLine(ForenameCheck);
            Console.WriteLine(forename);
        }
        public string ForenameCheck { get; set; }
        public string LastNameCheck { get; set; }
    }

}
