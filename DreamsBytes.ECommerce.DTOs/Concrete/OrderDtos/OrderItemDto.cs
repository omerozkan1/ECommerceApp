using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.ECommerce.DTOs.Concrete.OrderDtos
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
}
