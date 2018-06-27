using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Service.Pattern;
using Volunteering.Data;
using Volunteering.Data.Infrastructure;
using Volunteering.Domain.Entities;

namespace Volunteering.Service
{
    public class VoluntaryActionService : Service<VoluntaryAction>
    {
        
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        private static AppContext _context = new AppContext();

        public VoluntaryActionService() : base(ut)
        {

        }
        
        public IEnumerable<VoluntaryAction> GetActions()
        {
            return ut.GetRepository<VoluntaryAction>().GetAll().AsEnumerable();
        }


        public IEnumerable<ApplicationUser> GetParticipantsByActionId(int actionId)
        {
            VoluntaryAction action = ut.GetRepository<VoluntaryAction>().GetById(actionId);

            return null;
        }

        public IQueryable<VoluntaryAction> GetAllActions()
        {
            //return ut.GetRepository<VoluntaryAction>().GetAll().AsQueryable();
            return _context.VoluntaryActions.Include(a => a.Participants).Include(a => a.CreatorNgo).AsQueryable();
        }

        public Ngo GetNgoCreatorById(string id)
        {
            return ut.GetRepository<Ngo>().GetById(id);
        }
        public IEnumerable<Volunteer> GetAllParticipantsByAction(int id)
        {

            return ut.GetRepository<VoluntaryAction>().GetById(id).Participants;
        }

    
        public IEnumerable<VoluntaryAction> GetRecentActions()
        {

            return ut.GetRepository<VoluntaryAction>().GetAll().OrderByDescending(a => a.StartDate);
            
        }

    }
}
