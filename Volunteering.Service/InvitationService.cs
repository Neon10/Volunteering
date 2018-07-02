using Microsoft.AspNet.Identity;
using Service.Pattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Volunteering.Data.Infrastructure;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Enums;
using Volunteering.Service.Identity;


namespace Volunteering.Service
{
    public class InvitationService : Service<Invitation>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        private UserService User = new UserService();
        public InvitationService() : base(ut)
        {

        }



        public IEnumerable<Invitation> GetUnansweredInvites(string currentUserId)
        {
            
            return ut.GetRepository<Invitation>().GetMany(i => i.Status == InvitationStatus.Unanswered && i.VolunteerId.Equals(currentUserId));
        }


        public IEnumerable<Volunteer> GetDataOfInvite(string currentUserId)
        {

            return ut.GetRepository<Volunteer>().GetMany(i=>  i.Id.Equals(currentUserId));
        }
        public IEnumerable<Invitation> GetAcceptedInvites(string currentUserId)
        {

            return ut.GetRepository<Invitation>().GetMany(i => i.Status == InvitationStatus.Accepted && i.VolunteerId.Equals(currentUserId));
        }







        //public IEnumerable<VoluntaryAction> getA (int A)
        //{

        //    return ut.GetRepository<VoluntaryAction>().GetMany(i => i.ActionId == A);
        //}

        //public Volunteer getV(string A)
        //{

        //    return 
        //}

        public Boolean listAvalidate(string idV, int idA)
        {

            var result = ut.GetRepository<Invitation>().GetMany(x => x.VolunteerId == idV && x.ActionId==idA);


            if (result == null)
            {
                return true;
            }
            else
                return false;
        }

       

        public IEnumerable<Volunteer> GetInvi(int idA)
        {

            Invitation V = new Invitation();

            //ICollection<Invitation> collect = V.Invitations;
            
            //IEnumerable<Invitation> z = ut.GetRepository<Invitation>().GetMany(i => i.ActionId == idA );
            
            

              return ut.GetRepository<Volunteer>().GetMany(j => j.Id==V.VolunteerId && V.ActionId==idA);
                
            
          
        }

        public IEnumerable<VoluntaryAction> GetActionV(int idA)
        {

            
            
            return ut.GetRepository<VoluntaryAction>().GetMany(j => j.ActionId ==  idA);



        }

        public  IEnumerable<Invitation> GetAllInvites()
        {
            return ut.GetRepository<Invitation>().GetAll();
        }

        public IEnumerable<Invitation> FordeleteInv(int idA, string idV)
        {




            return ut.GetRepository<Invitation>().GetMany(j => j.ActionId == idA && j.VolunteerId == idV);



        }

        public int NumberOfInvitesIfExist(int idA, string idV)
        {




                   var linq = (from i in ut.GetRepository<Invitation>().GetMany(j => j.ActionId == idA && j.VolunteerId == idV)


                               select i);
            int count = linq.Count();
            return count;


        }

        public IEnumerable<Invitation> ForUpdateInv(int idA)
        {




            return ut.GetRepository<Invitation>().GetMany(j => j.InvitationId == idA);



        }

        public IEnumerable<Invitation> GetInvitOfSelectedAction(int idA)
        {
                 return ut.GetRepository<Invitation>().GetMany(j => j.ActionId == idA );
            
        }



        public IEnumerable<Volunteer> VolInvited(int idA)
        {
            var linq = (from i in ut.GetRepository<Invitation>().GetAll()
                        join x in ut.GetRepository<Volunteer>().GetAll() on i.VolunteerId equals x.Id
                        where (i.ActionId == idA)


                        select x);
            return linq;

        }

        public IEnumerable<Volunteer> VolNotInvited(int idA)
        {
            var linq = (from i in ut.GetRepository<Invitation>().GetMany(j => j.ActionId == idA)
                        join  x in ut.GetRepository<Volunteer>().GetAll() 
                        on i.VolunteerId equals x.UserName

                        where (i.VolunteerId != x.Id)
                        
                        select x);
            return linq;
        }

        public int countV(string idV)
        {
            var linq = (from i in ut.GetRepository<Invitation>().GetMany(j => j.VolunteerId == idV && j.Status == InvitationStatus.Unanswered)
                        

                                       select i);
            int count = linq.Count();
            return count;
        }


        public IEnumerable<VoluntaryAction> ActionOfCurrentVol(string currentUserId)
        {
            var linq = (from i in ut.GetRepository<Invitation>().GetAll()
                        join x in ut.GetRepository<VoluntaryAction>().GetAll()  on i.ActionId equals x.ActionId
                        where (i.Status == InvitationStatus.Unanswered && i.VolunteerId.Equals(currentUserId))


                        select x);
            return linq;

        }

        
        public virtual IEnumerable<Volunteer> GetInvites()
        {
            return ut.GetRepository<Volunteer>().GetAll();
        }

       
       
    }
    }
