using DreamsBytes.ECommerce.DataAccess.Concrete.EntityFrameworkCore.Context;
using DreamsBytes.ECommerce.DataAccess.Interfaces;
using DreamsBytes.ECommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DreamsBytes.ECommerce.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfOrderRepository : EfGenericRepository<Order>, IOrderDal
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new DatabaseContext())
            {
                var orders = context.Orders
                                .Include(i => i.OrderItems)
                                .ThenInclude(i => i.Product)
                                .AsQueryable();

                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i => i.AppUserId == userId);
                }

                return orders.ToList();
            }
        }
    }
}
