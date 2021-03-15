using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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

        public async Task<IActionResult> OnPostAsync()
        {
            //Product = await db.Products.FindAsync(Id);  some sort of await command here, so this runs when a command succeeds
            if (ModelState.IsValid)
            {
                Console.WriteLine("Writing to database:");
                Console.WriteLine("ID: " + Id);
                Console.WriteLine("Forename: " + Forename);
                Console.WriteLine("Middle names: " + MiddleNames);
                Console.WriteLine("Last name: " + LastName);
                Console.WriteLine("Email address: " + EmailAddress);


                return RedirectToPage("PositiveFormSuccess", "Form success", new { forename = Forename, lastName = LastName});
            }
            return Page();
        }


        public int Id { get; set; }

        
        [BindProperty, Required(ErrorMessage = "Please supply a forename"), Display(Name = "Forename")]
        public string Forename { get; set; }

        [BindProperty, Display(Name = "Middle Names (Optional)")]
        public string MiddleNames { get; set; }

        [BindProperty, Required(ErrorMessage = "Please supply a last name"), Display(Name = "Last name")]
        public string LastName { get; set; }

        [EmailAddress]
        [BindProperty, Required(ErrorMessage = "Please supply a valid email address"), Display(Name = "Email address")]
        public string EmailAddress { get; set; }
        
        
    }

}
