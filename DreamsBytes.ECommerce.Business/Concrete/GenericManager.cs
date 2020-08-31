using DreamsBytes.ECommerce.Business.Interfaces;
using DreamsBytes.ECommerce.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DreamsBytes.ECommerce.Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class, new()
    {
        private readonly IGenericDal<T> _genericDal;
        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void Create(T entity)
        {
            _genericDal.Create(entity);
        }

        public void Delete(T entity)
        {
            _genericDal.Delete(entity);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return _genericDal.GetAll();
        }

        public T GetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            return _genericDal.GetOne(filter);
        }

        public void Update(T entity)
        {
            _genericDal.Update(entity);
        }
    }
}
