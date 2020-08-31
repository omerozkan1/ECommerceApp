using System.Collections.Generic;

namespace DreamsBytes.ECommerce.Entities.Concrete
{
    public class Cart
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
