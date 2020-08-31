using DreamsBytes.ECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace DreamsBytes.ECommerce.Business.Interfaces
{
    public interface IOrderService
    {
        void Create(Order entity);
        List<Order> GetOrders(string userId);
    }
}
