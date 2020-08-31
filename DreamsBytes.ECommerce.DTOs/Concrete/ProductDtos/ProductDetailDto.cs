using DreamsBytes.ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.ECommerce.DTOs.Concrete.ProductDtos
{
    public class ProductDetailDto
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
