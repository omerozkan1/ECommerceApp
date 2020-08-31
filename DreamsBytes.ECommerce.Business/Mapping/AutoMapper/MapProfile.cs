using AutoMapper;
using DreamsBytes.ECommerce.DTOs.Concrete.ProductDtos;
using DreamsBytes.ECommerce.Entities.Concrete;

namespace DreamsBytes.ECommerce.Business.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductAddDto>();
        }
    }
}
