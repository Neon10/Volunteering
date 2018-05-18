namespace Volunteering.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private AppContext dataContext;
        public AppContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new AppContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
