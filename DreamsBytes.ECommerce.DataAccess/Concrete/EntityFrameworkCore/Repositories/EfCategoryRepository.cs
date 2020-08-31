using DreamsBytes.ECommerce.DataAccess.Concrete.EntityFrameworkCore.Context;
using DreamsBytes.ECommerce.DataAccess.Interfaces;
using DreamsBytes.ECommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DreamsBytes.ECommerce.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
        public void DeleteFromCategory(int categoryId, int productId)
        {
            using (var context = new DatabaseContext())
            {
                var cmd = @"delete from ProductCategory where ProductId=@p0 And CategoryId=@p1";
                context.Database.ExecuteSqlCommand(cmd, productId, categoryId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Categories
                        .Where(i => i.Id == id)
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Product)
                        .FirstOrDefault();
            }
        }
    }
}
