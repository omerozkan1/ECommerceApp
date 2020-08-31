using DreamsBytes.ECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace DreamsBytes.ECommerce.WebUI.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
