using DreamsBytes.ECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace DreamsBytes.ECommerce.DataAccess.Interfaces
{
    public interface IOrderDal: IGenericDal<Order>
    {
        List<Order> GetOrders(string AppUserId);
    }
}
