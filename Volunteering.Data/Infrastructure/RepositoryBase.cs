using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Volunteering.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private AppContext _dataContext;
        private readonly IDbSet<T> _dbset;
        IDatabaseFactory _databaseFactory;
        public RepositoryBase(IDatabaseFactory dbFactory)
        {
            this._databaseFactory = dbFactory;
            _dbset = DataContext.Set<T>();


        }
        protected AppContext DataContext
        {
            get { return _dataContext = _databaseFactory.DataContext; }
        }

        #region Synch Methods
        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbset.Remove(obj);
        }
        public virtual T GetById(long id)
        {
            return _dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return _dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null, Expression<Func<T, bool>> orderBy = null)
        {
            IQueryable<T> query = _dbset;
            if (where != null)
            {
                query = query.Where(where);
            }
            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }
            return query;
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault<T>();
        }
        #endregion


        #region Async methos


        //public async Task<int> CountAsync()
        //{
        //    return await dbset.CountAsync();
        //}

        //public async Task<List<T>> GetAllAsync()
        //{
        //    return await dbset.ToListAsync();
        //}

        //public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        //{
        //    return await dbset.SingleOrDefaultAsync(match);
        //}

        //public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match)
        //{
        //    return await dbset.Where(match).ToListAsync();
        //}
        #endregion
    }
}
