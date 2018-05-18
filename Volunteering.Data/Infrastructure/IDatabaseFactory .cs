using System;

namespace Volunteering.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        AppContext DataContext { get; }
    }

}
