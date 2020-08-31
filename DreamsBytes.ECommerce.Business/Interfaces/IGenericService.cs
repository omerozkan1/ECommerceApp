using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DreamsBytes.ECommerce.Business.Interfaces
{
    public interface IGenericService<T> where T : class, new()
    {
        T GetById(int id);
        T GetOne(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
