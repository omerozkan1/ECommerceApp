using DreamsBytes.ECommerce.DTOs.Concrete;
using DreamsBytes.ECommerce.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamsBytes.ECommerce.DataAccess.Interfaces
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        Product GetProductDetails(int id);
        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
    }
}
