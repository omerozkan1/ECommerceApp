using System.Linq;
using System.Threading.Tasks;
using DreamsBytes.ECommerce.Business.Interfaces;
using DreamsBytes.ECommerce.DTOs.Concrete.CategoryDtos;
using DreamsBytes.ECommerce.DTOs.Concrete.ProductDtos;
using DreamsBytes.ECommerce.Entities.Concrete;
using DreamsBytes.ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamsBytes.ECommerce.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult ProductList()
        {
            return View(new ProductListDto()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductAddDto model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    StockQuantity = model.StockQuantity,
                };

                if (_productService.Create(entity))
                {
                    return RedirectToAction("ProductList");
                }
                ViewBag.ErrorMessage = _productService.ErrorMessage;
                return View(model);

            }

            return View(model);
        }

        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetByIdWithCategories((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                StockQuantity = entity.StockQuantity,
                SelectedCategories = entity.ProductCategories.Select(i => i.Category).ToList()
            };

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductModel model, int[] categoryIds)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.GetById(model.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.Name = model.Name;
                entity.StockQuantity = model.StockQuantity;
                entity.Price = model.Price;           

                _productService.Update(entity, categoryIds);

                return RedirectToAction("ProductList");
            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        public IActionResult DeleteProduct(int id)
        {
            _productService.Delete(new Product { Id = id });
            return Json(null);
        }
      

        public IActionResult CategoryList()
        {
            return View(new CategoryListDto()
            {
                Categories = _categoryService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name
            };
            _categoryService.Create(entity);

            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = _categoryService.GetByIdWithProducts(id);

            return View(new CategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Products = entity.ProductCategories.Select(p => p.Product).ToList()
            });
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            _categoryService.Update(entity);

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);

            if (entity != null)
            {
                _categoryService.Delete(entity);
            }

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteFromCategory(int categoryId, int productId)
        {
            _categoryService.DeleteFromCategory(categoryId, productId);
            return Redirect("/admin/editcategory/" + categoryId);
        }
    }
}