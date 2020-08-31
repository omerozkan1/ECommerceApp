using DreamsBytes.ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.ECommerce.DTOs.Concrete.CategoryDtos
{
    public class CategoryAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
