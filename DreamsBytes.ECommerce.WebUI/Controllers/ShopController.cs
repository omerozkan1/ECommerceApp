using System.Linq;
using DreamsBytes.ECommerce.Business.Interfaces;
using DreamsBytes.ECommerce.DTOs.Concrete.ProductDtos;
using DreamsBytes.ECommerce.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamsBytes.ECommerce.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailDto()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });
        }

        //products/elma?page=2
        public IActionResult List(string category, int page = 1)
        {
            const int pageSize = 15;
            return View(new ProductListDto()
            {
                Products = _productService.GetProductsByCategory(category, page, pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentCategory = category
                }
            });
        }
    }
}