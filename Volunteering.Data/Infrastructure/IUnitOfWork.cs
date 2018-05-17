using System;

namespace Volunteering.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<T> getRepository<T>() where T : class;

        void Commit();

    }

}
