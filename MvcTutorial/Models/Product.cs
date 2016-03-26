using System.Collections.Generic;

namespace MvcTutorial.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PriceInCents { get; set; }
        public virtual ICollection<ProductReview> Reviews { get; set; }
    }

    public class ProductReview
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}