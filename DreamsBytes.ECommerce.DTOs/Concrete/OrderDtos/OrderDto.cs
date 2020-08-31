using DreamsBytes.ECommerce.DTOs.Concrete.CartDtos;

namespace DreamsBytes.ECommerce.DTOs.Concrete.OrderDtos
{
    public class OrderDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public CartDto CartDto { get; set; }
    }
}
