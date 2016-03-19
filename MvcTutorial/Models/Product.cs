using System.ComponentModel.DataAnnotations;

namespace MvcTutorial.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int PriceInCents { get; set; }
    }
}