using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteering.Data.Infrastructure;
using Volunteering.Domain.Entities;

namespace Volunteering.Service
{
    public class DonationService : Service<Donation>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public DonationService() : base(ut)
        {
        }

        public IEnumerable<Donation> GetAllDonations()
        {

            var res = ut.GetRepository<Donation>().GetAll();

            return res;
        }
    }
}
