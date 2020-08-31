using System;
using System.Collections.Generic;
using System.Linq;
using DreamsBytes.ECommerce.Business.Interfaces;
using DreamsBytes.ECommerce.DTOs.Concrete.CartDtos;
using DreamsBytes.ECommerce.DTOs.Concrete.OrderDtos;
using DreamsBytes.ECommerce.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DreamsBytes.ECommerce.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private UserManager<AppUser> _userManager;

        public CartController(IOrderService orderService, ICartService cartService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _cartService = cartService;
            _userManager = userManager;
        }
        public IActionResult Index()
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
        
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            _cartService.AddToCart(_userManager.GetUserId(User), productId, quantity);
            return RedirectToAction("ProductList", "Admin");
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            _cartService.DeleteFromCart(_userManager.GetUserId(User), productId);
            return RedirectToAction("Index");
        }       

        public IActionResult Checkout()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));

            var orderModel = new OrderDto();

            orderModel.CartDto = new CartDto()
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
            };

            return View(orderModel);
        }

        [HttpPost]
        public IActionResult Checkout(OrderDto model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var cart = _cartService.GetCartByUserId(userId);

                model.CartDto = new CartDto()
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
                };
              
                SaveOrder(model, userId);
                ClearCart(cart.Id.ToString());
                return RedirectToAction("ProductList", "Admin");
            }

            return View(model);
        }

        private void SaveOrder(OrderDto model, string userId)
        {
            var order = new Order();

            order.OrderNumber = new Random().Next(111111, 999999).ToString();
            order.OrderState = EnumOrderState.Completed;
            order.OrderDate = DateTime.Now;   
            order.AppUserId = userId;
            order.TotalPrice = model.CartDto.TotalPrice();

            foreach (var item in model.CartDto.CartItems)
            {
                var orderitem = new OrderItem()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                order.OrderItems.Add(orderitem);
            }
            _orderService.Create(order);
        }

        private void ClearCart(string cartId)
        {
            _cartService.ClearCart(cartId);
        }       

        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders(_userManager.GetUserId(User));
            var orderListModel = new List<OrderListDto>();
            OrderListDto orderModel;

            foreach (var order in orders)
            {
                orderModel = new OrderListDto();
                orderModel.OrderId = order.Id;
                orderModel.OrderNumber = order.OrderNumber;
                orderModel.OrderDate = order.OrderDate;

                orderModel.OrderItems = order.OrderItems.Select(i => new OrderItemDto()
                {
                    OrderItemId = i.Id,
                    Name = i.Product.Name,
                    Price = i.Price,
                    Quantity = i.Quantity,
                }).ToList();

                orderListModel.Add(orderModel);
            }

            return View(orderListModel);
        }
    }
}