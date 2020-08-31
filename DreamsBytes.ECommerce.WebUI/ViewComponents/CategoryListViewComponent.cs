using DreamsBytes.ECommerce.Business.Interfaces;
using DreamsBytes.ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamsBytes.ECommerce.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                SelectedCategory = RouteData.Values["category"]?.ToString(),
                Categories = _categoryService.GetAll()
            });
        }
    }
}
