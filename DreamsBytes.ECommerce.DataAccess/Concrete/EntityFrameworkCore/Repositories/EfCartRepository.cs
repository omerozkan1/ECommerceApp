using DreamsBytes.ECommerce.DataAccess.Concrete.EntityFrameworkCore.Context;
using DreamsBytes.ECommerce.DataAccess.Interfaces;
using DreamsBytes.ECommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DreamsBytes.ECommerce.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCartRepository : EfGenericRepository<Cart>, ICartDal
    {       
        public override void Update(Cart entity)
        {
            using (var context = new DatabaseContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }

        public Cart GetByUserId(string userId)
        {
            using (var context = new DatabaseContext())
            {
                return context
                            .Carts
                            .Include(i => i.CartItems)
                            .ThenInclude(i => i.Product)
                            .FirstOrDefault(i => i.AppUserId == userId);
            }
        }

        [System.Obsolete]
        public void DeleteFromCart(int cartId, int productId)
        {
            using (var context = new DatabaseContext())
            {
                var cmd = @"delete from CartItems where CartId=@p0 And ProductId=@p1";
                context.Database.ExecuteSqlCommand(cmd, cartId, productId);
            }
        }

        [System.Obsolete]
        public void ClearCart(string cartId)
        {
            using (var context = new DatabaseContext())
            {
                var cmd = @"delete from CartItems where CartId=@p0";
                context.Database.ExecuteSqlCommand(cmd, cartId);
            }
        }        
    }
}
