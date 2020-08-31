using DreamsBytes.ECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace DreamsBytes.ECommerce.Business.Interfaces
{
    public interface ICategoryService
    {
        Category GetById(int id);
        Category GetByIdWithProducts(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        void DeleteFromCategory(int categoryId, int productId);
    }
}
