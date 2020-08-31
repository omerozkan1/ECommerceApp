using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamsBytes.ECommerce.Business.Interfaces;
using DreamsBytes.ECommerce.DTOs.Concrete.CartDtos;
using DreamsBytes.ECommerce.DTOs.Concrete.ProductDtos;
using DreamsBytes.ECommerce.DTOs.StringInfos;
using DreamsBytes.ECommerce.Entities.Concrete;
using DreamsBytes.ECommerce.WebUI.BaseControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DreamsBytes.ECommerce.WebUI.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        public HomeController(IProductService productService, ICartService cartService, UserManager<AppUser> userManager) : base(userManager)
        {
            _cartService = cartService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(new ProductListDto()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            _cartService.AddToCart(_userManager.GetUserId(User), productId, quantity);
            return RedirectToAction("Index");
        }


        public IActionResult Cart()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartDto()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemDto()
                {
                    CartItemId = i.Id,
                    ProductId = i.Product.Id,
                    Name = i.Product.Name,
                    Price = (decimal)i.Product.Price,
                    Quantity = i.Quantity
                }).ToList()
            });
        }
    }
}