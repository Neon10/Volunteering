namespace Volunteering.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
       
         private AppContext dataContext;

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dataContext = dbFactory.DataContext;
        }
        


        public void Commit()
        {
            dataContext.SaveChanges();
        }
        
        public void Dispose()
        {
            dataContext.Dispose();
        }
        public IRepositoryBase<T> getRepository<T>() where T : class
        {
            IRepositoryBase<T> repo = new RepositoryBase<T>(dbFactory);
            return repo;
        }
      
    }
}
