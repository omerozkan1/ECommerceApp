using System.Collections.Generic;

namespace DreamsBytes.ECommerce.Entities.Concrete
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
