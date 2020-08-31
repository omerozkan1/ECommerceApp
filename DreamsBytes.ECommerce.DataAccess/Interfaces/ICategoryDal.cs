using DreamsBytes.ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.ECommerce.DataAccess.Interfaces
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        Category GetByIdWithProducts(int id);
        void DeleteFromCategory(int categoryId, int productId);
    }
}
