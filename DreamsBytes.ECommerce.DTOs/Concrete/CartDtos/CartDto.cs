using System.Collections.Generic;
using System.Linq;

namespace DreamsBytes.ECommerce.DTOs.Concrete.CartDtos
{
    public class CartDto
    {
        public int CartId { get; set; }
        public List<CartItemDto> CartItems { get; set; }

        public decimal TotalPrice()
        {
            return CartItems.Sum(i => i.Price * i.Quantity);
        }
    }
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

}
