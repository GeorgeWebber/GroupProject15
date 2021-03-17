using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
//using GroupProject15.Models;
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
            //Product = await db.PositiveCases.FindAsync(Id);  some sort of await command here, so this runs when a command succeeds
            var results = new List<ValidationResult>();   //contains the errors from validation, if any. Currrently does not display this to user
            if (Validator.TryValidateObject(caseForm, new ValidationContext(caseForm, null, null), results, false))
            {
                HttpContext.Session.SetString("Case Name", caseForm.Forename);   //just testing setting session variables, is not useful
                return RedirectToPage("PositiveFormSuccess");
            }
            return Page();
        }

        [BindProperty]
        public ValidateableCaseForm caseForm { get; set; }

       
    }

    public class ValidateableCaseForm : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrWhiteSpace(EmailAddress) && String.IsNullOrWhiteSpace(PhoneNumber))
            {
                yield return new ValidationResult("Must supply a contact method for patient", new[] { "EmailAddress", "PhoneNumber" });
            }
        }

        public int Id { get; set; }


        [ Required(ErrorMessage = "Please supply a forename"), Display(Name = "Forename")]
        public string Forename { get; set; }

        [Required(ErrorMessage = "Please supply a last name"), Display(Name = "Last name")]
        public string LastName { get; set; }

        //TODO check this regex
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please supply a valid email address")]
        [EmailAddress]  //also performs email address validation, replaces the regex
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter date when sample was taken"), Display(Name = "Date of Test")]
        public DateTime? TestDate { get; set; }

        [Display(Name = "When Symptoms Started")]
        public DateTime? SymptomDate { get; set; }

        [Required(ErrorMessage = "Please supply first half of patient postcode"), Display(Name = "Postcode")]
        [RegularExpression(@"([a-z]|[A-Z]){1,2}[0-9]{1,2}", ErrorMessage = "Please enter first half of Patient's Postcode, e.g AA01")]
        public String Postcode { get; set; }
    }

}
