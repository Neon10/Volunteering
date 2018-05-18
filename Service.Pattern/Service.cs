using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Volunteering.Data.Infrastructure;


namespace Service.Pattern
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        readonly IUnitOfWork _utwk;



        protected Service(IUnitOfWork utwk)
        {
            _utwk = utwk;
        }




        public virtual void Add(TEntity entity)
        {
            ////_repository.Add(entity);
            _utwk.GetRepository<TEntity>().Add(entity);

        }

        public virtual void Update(TEntity entity)
        {
            //_repository.Update(entity);
            _utwk.GetRepository<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            //   _repository.Delete(entity);
            _utwk.GetRepository<TEntity>().Delete(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            // _repository.Delete(where);
            _utwk.GetRepository<TEntity>().Delete(where);
        }

        public virtual TEntity GetById(long id)
        {
            //  return _repository.GetById(id);
            return _utwk.GetRepository<TEntity>().GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _utwk.GetRepository<TEntity>().GetAll();
            //return _repository.GetById(id);
            //  return utwk.getRepository<TEntity>().GetById(id);
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> orderBy = null)
        {
            //  return _repository.GetAll();
            return _utwk.GetRepository<TEntity>().GetMany(filter, orderBy);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            //return _repository.Get(where);
            return _utwk.GetRepository<TEntity>().Get(where);
        }



        public void Commit()
        {
            _utwk.Commit();
        }


        public void Dispose()
        {
            _utwk.Dispose();
        }
    }
}
