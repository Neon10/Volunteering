using Service.Pattern;
using System.Collections.Generic;
using System.Linq;
using Volunteering.Data.Infrastructure;
using Volunteering.Domain.Entities;
using Volunteering.Service.Identity;
using Microsoft.AspNet.Identity;
using System.Collections;

namespace Volunteering.Service
{
    public class FundraisingCampaignService : Service<FundraisingCampaign>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);



        public FundraisingCampaignService() : base(ut)
        {
        }

        //Example
        public IEnumerable<FundraisingCampaign> GetAllCampaigns()
        {

            var res = ut.GetRepository<FundraisingCampaign>().GetAll();

            return res;
        }

        public IQueryable<FundraisingCampaign> QueryCampaigns()
        {

            var res = ut.GetRepository<FundraisingCampaign>().GetAll().AsQueryable();

            return res;
        }

        // GET current amout of donations for provided Campaign id
        public int TotalDonations(int id)
        {
            return ut.GetRepository<FundraisingCampaign>().GetById(id).Donations.Sum(d => d.Amount);
        }

        // GET FundraisingCampaign by NGO
        public IEnumerable FundraisingCompaignByNgo()
        {
            UserService us = new UserService();
            List<FundraisingCampaign> Funds = new List<FundraisingCampaign>();

            //var iduser = System.Web.HttpContext.Current.User.Identity.GetUserId();

            Funds = ut.GetRepository<FundraisingCampaign>().GetAll().ToList();

            Ngo ngo = us.UserManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()) as Ngo;

            foreach (var fund in Funds)
            {
                if (fund.OwnerNgo == ngo)
                {
                    Funds.Remove(fund);
                }
            }

            return Funds;
        }









    }
}
