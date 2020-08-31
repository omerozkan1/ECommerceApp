using DreamsBytes.ECommerce.Entities.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamsBytes.ECommerce.DTOs.Concrete.ProductDtos
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public decimal? Price { get; set; }
        public int CategoryId { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
