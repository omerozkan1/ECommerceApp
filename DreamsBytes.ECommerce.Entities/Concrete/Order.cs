using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamsBytes.ECommerce.Entities.Concrete
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string AppUserId { get; set; }
        public EnumOrderState OrderState { get; set; }
        public EnumPaymentTypes? PaymentTypes { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public enum EnumOrderState
    {
        waiting = 0,
        Unpaid = 1,
        Completed = 2
    }

    public enum EnumPaymentTypes
    {
        CreditCart = 0,
        Eft = 1
    }
}
