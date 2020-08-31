using DreamsBytes.ECommerce.DTOs.Concrete;
using DreamsBytes.ECommerce.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamsBytes.ECommerce.Business.Interfaces
{
    public interface IProductService : IValidator<Product>
    {
        Product GetById(int id);
        Product GetByIdWithCategories(int id);
        Product GetProductDetails(int id);
        List<Product> GetAll();
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        int GetCountByCategory(string category);
        bool Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        void Update(Product entity, int[] categoryIds);
    }
}
