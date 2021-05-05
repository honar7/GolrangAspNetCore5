using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Session11.WebAPIs.Models
{
    public class ProductInputDto
    {
        [Required]
        public string Name { get; set; }
        [StringLength(500,MinimumLength =20)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                CategoryId = CategoryId,
                Description = Description,
                Name = Name,
                Price = Price
            };
        }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
