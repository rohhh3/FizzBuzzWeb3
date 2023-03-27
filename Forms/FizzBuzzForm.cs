using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {
        [DisplayName("Wprowadź rok")]
        [Required(ErrorMessage = "Te pole jest wymagane.")]
        [Range(1899, 2022, ErrorMessage = "Zakres 1899-2022") ]
        public int Year { get; set; }

        [DisplayName("Wprowadź imię")]
        [Required(ErrorMessage = "Te pole jest wymagane.")]
        [MaxLength(100, ErrorMessage = "Maksymalnie 100 znaków.")]
        public string? Name { get; set; }
        public string? Information { get;set; }

        public List<FizzBuzzForm> People { get; set; }
    }
}
