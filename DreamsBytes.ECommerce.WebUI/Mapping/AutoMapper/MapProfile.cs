using AutoMapper;
using DreamsBytes.ECommerce.DTOs.Concrete.AppUserDtos;
using DreamsBytes.ECommerce.DTOs.Concrete.CartDtos;
using DreamsBytes.ECommerce.DTOs.Concrete.CategoryDtos;
using DreamsBytes.ECommerce.DTOs.Concrete.OrderDtos;
using DreamsBytes.ECommerce.DTOs.Concrete.ProductDtos;
using DreamsBytes.ECommerce.Entities.Concrete;

namespace DreamsBytes.ECommerce.WebUI.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region AppUser-AppUserDto
            CreateMap<AppUserLoginDto, AppUser>();
            CreateMap<AppUser, AppUserLoginDto>();
            #endregion

            #region Cart-CartDto
            CreateMap<CartDto, Cart>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartItemDto, Cart>();
            CreateMap<Cart, CartItemDto>();
            #endregion

            #region Category-CategoryDto
            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();
            #endregion

            #region Order-OrderDto
            CreateMap<OrderDto, Order>();
            CreateMap<Category, OrderDto>();
            CreateMap<OrderItemDto, Order>();
            CreateMap<Order, OrderItemDto>();
            CreateMap<OrderListDto, Order>();
            CreateMap<Order, OrderListDto>();
            #endregion

            #region Product-ProductDto
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductAddDto>();
            CreateMap<ProductListDto, Product>();
            CreateMap<Product, ProductListDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();
            #endregion
          
        }

    }
}
