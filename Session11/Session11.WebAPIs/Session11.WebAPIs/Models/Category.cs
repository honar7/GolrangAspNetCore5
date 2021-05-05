using System.Collections.Generic;

namespace Session11.WebAPIs.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
