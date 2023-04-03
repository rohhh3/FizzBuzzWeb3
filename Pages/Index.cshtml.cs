using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]

        public FizzBuzzForm FizzBuzz { get; set; }

        public Session FizzBuzzSession { get; set; } = new Session();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            if ((FizzBuzz.Year % 4 == 0 && FizzBuzz.Year % 100 != 0) || FizzBuzz.Year % 400 == 0)
                FizzBuzz.Information = "rok przestępny.";
             
            else
                FizzBuzz.Information = "rok nieprzestępny";

            ViewData["year"] = FizzBuzz.Information;

            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", FizzBuzz.Name);
                HttpContext.Session.SetInt32("year", FizzBuzz.Year);
                HttpContext.Session.SetString("if_leap_year", FizzBuzz.Information);
            }

            if(!String.IsNullOrEmpty(FizzBuzz.Name) && !String.IsNullOrEmpty(FizzBuzz.Year.ToString()))
            {
                var CurrentData = HttpContext.Session.GetString("CurrentData");
                if(CurrentData != null)
                    FizzBuzzSession = JsonConvert.DeserializeObject<Session>(CurrentData);

                FizzBuzzSession.SessionList.Add(FizzBuzz);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(FizzBuzzSession));
                HttpContext.Session.SetString("CurrentData", JsonConvert.SerializeObject(FizzBuzzSession));
            }
            return Page();
        }
    }
}