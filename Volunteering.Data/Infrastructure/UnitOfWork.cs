namespace Volunteering.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
       
         private AppContext _dataContext;

        IDatabaseFactory _dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this._dbFactory = dbFactory;
            _dataContext = dbFactory.DataContext;
        }
        


        public void Commit()
        {
            _dataContext.SaveChanges();
        }
        
        public void Dispose()
        {
            _dataContext.Dispose();
        }
        public IRepositoryBase<T> GetRepository<T>() where T : class
        {
            IRepositoryBase<T> repo = new RepositoryBase<T>(_dbFactory);
            return repo;
        }
      
    }
}
