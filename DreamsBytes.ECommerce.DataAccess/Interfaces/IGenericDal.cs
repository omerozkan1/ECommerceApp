using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DreamsBytes.ECommerce.DataAccess.Interfaces
{
    public interface IGenericDal<T>
    {
        T GetById(int id);
        T GetOne(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
