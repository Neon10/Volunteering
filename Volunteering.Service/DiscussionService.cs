using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteering.Data;
using Volunteering.Data.Infrastructure;
using Volunteering.Domain.Entities;

namespace Volunteering.Service
{
    public class DiscussionService : Service<Discussion>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        private readonly AppContext context = new AppContext();


        public DiscussionService() : base(ut)
        {
        }


        public IEnumerable<Discussion> GetAllDiscussions()
        {
            return ut.GetRepository<Discussion>().GetAll();

        }





    }
}
