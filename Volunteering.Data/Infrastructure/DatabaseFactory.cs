namespace Volunteering.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private AppContext _dataContext;
        public AppContext DataContext { get { return _dataContext; } }

        public DatabaseFactory()
        {
            _dataContext = new AppContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
