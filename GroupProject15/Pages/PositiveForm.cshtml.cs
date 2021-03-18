using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
//using GroupProject15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//TODO full validation on all fields
//TODO add rest of fields

namespace GroupProject15.Pages
{
    public class PositiveFormModel : PageModel
    {
        public void OnGet()
        {
        }
        private readonly ILogger<PositiveFormModel> _logger;

        public PositiveFormModel(ILogger<PositiveFormModel> logger)
        {
            _logger = logger;
        }

        public int Id { get; set; }


        [BindProperty, Required(ErrorMessage = "Please supply a forename"), Display(Name = "Forename")]
        public string Forename { get; set; }

        [BindProperty, Required(ErrorMessage = "Please supply a last name"), Display(Name = "Last name")]
        public string LastName { get; set; }

        //TODO check this regex
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please supply a valid email address")]
        [BindProperty, Required(ErrorMessage = "Please supply a valid email address"), Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //Product = await db.Products.FindAsync(Id);  some sort of await command here, so this runs when a command succeeds
            if (ModelState.IsValid)
            {
                return RedirectToPage("PositiveFormSuccess");
            }
            return Page();
        }

        
       
    }

        
        
      

}
