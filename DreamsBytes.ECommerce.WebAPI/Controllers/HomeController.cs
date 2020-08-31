using AutoMapper;
using DreamsBytes.ECommerce.Business.Interfaces;
using DreamsBytes.ECommerce.DTOs.Concrete.ProductDtos;
using DreamsBytes.ECommerce.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamsBytes.ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public HomeController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            return Ok(_productService.GetAll());
        }

        [HttpPost("[action]")]
        public IActionResult AddProduct(ProductAddDto model)
        {
            _productService.Create(_mapper.Map<Product>(model));
            return Created("", model);
        }
    }
}