using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Volunteering.Data.Infrastructure
{
    public interface IRepositoryBase<T>
     where T : class
    {
        void Add(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> where);

        T GetById(long id);
        T GetById(string id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null, Expression<Func<T, bool>> orderBy = null);

        void Update(T entity);
        IEnumerable<T> GetAll();


    }
}
