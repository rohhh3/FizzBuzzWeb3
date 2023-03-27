using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public FizzBuzzForm FizzBuzz { get; set; }

        public string? Name { get; set; }
        public int?    Year { get; set; }
        public string Information { get; set; }

        public void OnGet()
        {
            Name        = HttpContext.Session.GetString("name");
            Year        = HttpContext.Session.GetInt32("year");
            Information = HttpContext.Session.GetString("if_leap_year");
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
