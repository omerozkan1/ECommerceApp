using DreamsBytes.ECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace DreamsBytes.ECommerce.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public decimal? Price { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
