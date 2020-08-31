using DreamsBytes.ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamsBytes.ECommerce.DTOs.Concrete.OrderDtos
{
    public class OrderListDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        public EnumPaymentTypes? PaymentTypes { get; set; }

        public string FullName { get; set; }
        public string Phone { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

        public decimal TotalPrice()
        {
            return OrderItems.Sum(i => i.Price * i.Quantity);
        }
    }
}
