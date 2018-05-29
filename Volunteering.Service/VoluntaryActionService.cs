using Service.Pattern;
using Volunteering.Data.Infrastructure;
using Volunteering.Domain.Entities;

namespace Volunteering.Service
{
    public class VoluntaryActionService : Service<VoluntaryAction>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public VoluntaryActionService() : base(ut)
        {

        }
    }
}
