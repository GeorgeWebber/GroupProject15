using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
//using GroupProject15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupProject15.Pages
{
    public class PositiveFormModel : PageModel
    {
        public void OnGet()
        {
        }

        public int Id { get; set; }
        [BindProperty, Id, Required, Display (Name ="Id")]
        public string Forename { get; set; }
        public string EmailAddress { get; set; }
    }
}
