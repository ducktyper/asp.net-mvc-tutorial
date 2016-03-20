using System.ComponentModel.DataAnnotations;

namespace MvcTutorial.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Label")]
        [Required(ErrorMessage = "{0} is required!")]
        public string Name { get; set; }
        public int PriceInCents { get; set; }
    }
}