using System.Collections.Generic;

namespace DreamsBytes.ECommerce.Entities.Concrete
{
    public class Product
    {      
        public int Id { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public decimal? Price { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }

    }
}
