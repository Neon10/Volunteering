using Service.Pattern;
using System.Collections.Generic;
using System.Linq;
using Volunteering.Data.Infrastructure;
using Volunteering.Domain.Entities;

namespace Volunteering.Service
{
    public class FundraisingCampaignService : Service<FundraisingCampaign>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);



        public FundraisingCampaignService() : base(ut)
        {
        }




        // GET current amout of donations for provided Campaign id
        public int TotalDonations(int id)
        {
            return ut.GetRepository<FundraisingCampaign>().GetById(id).Donations.Sum(d => d.Amount);
        }

        //Example
        public IEnumerable<FundraisingCampaign> GetAllCampaigns()
        {

            var res = ut.GetRepository<FundraisingCampaign>().GetAll();

            return res;
        }

    }
}
