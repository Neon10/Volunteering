using Service.Pattern;
using System.Collections.Generic;
using Volunteering.Data.Infrastructure;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Enums;

namespace Volunteering.Service
{
    public class InvitationService : Service<Invitation>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public InvitationService() : base(ut)
        {
        }



        public IEnumerable<Invitation> GetUnansweredInvites()
        {
            return ut.GetRepository<Invitation>().GetMany(i => i.Status == InvitationStatus.Unanswered);
        }



    }
}
