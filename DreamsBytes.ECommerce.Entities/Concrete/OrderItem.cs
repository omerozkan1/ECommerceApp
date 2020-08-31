namespace DreamsBytes.ECommerce.Entities.Concrete
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public EnumPaymentTypes PaymentTypes { get; set; }
    }
}
