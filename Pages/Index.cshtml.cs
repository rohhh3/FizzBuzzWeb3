using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]

        public FizzBuzzForm FizzBuzz { get; set; }
        [BindProperty(SupportsGet = true)]

        public string Name { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
                Name = "User";
        }
        public IActionResult OnPost()
        {
            string information, message;
            if ((FizzBuzz.Year % 4 == 0 && FizzBuzz.Year % 100 != 0) || FizzBuzz.Year % 400 == 0)
            {
                information = "rok przestępny.";
            }
             
            else
            {
                information = "rok nieprzestępny";
            }
               
            message = FizzBuzz.Name + " urodził się w " + FizzBuzz.Year + " roku. "
                    + "Był to " + information;

            if (ModelState.IsValid)
            {
                ViewData["message"] = message;
                HttpContext.Session.SetString("name", FizzBuzz.Name);
                HttpContext.Session.SetInt32("year", FizzBuzz.Year);
                HttpContext.Session.SetString("if_leap_year", information);
            }
            return Page();
        }
    }
}