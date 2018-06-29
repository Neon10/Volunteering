using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Volunteering.Domain.DtoInvitation;
using Volunteering.Domain.Entities;
using Volunteering.Service;

namespace Volunteering.UI.Controllers_Api
{[RoutePrefix ("api/Invitation")]
    public class InvitationController : ApiController
    {
       


         public InvitationService _IS = new InvitationService();

        // GET: api/Invitation
        [Route("test")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Invitation
        [Route("Getinvites")]
        [ResponseType(typeof(Invitation))]
        public List<InvitationDto> Getinv()
        {



            IEnumerable<Invitation> invitations = _IS.GetAllInvites();
            List<InvitationDto> vaDtos = new List<InvitationDto>();


            foreach (Invitation a in invitations)
            {
                InvitationDto vd = new InvitationDto();
                vd.InvitationId = a.InvitationId;
                vd.Status = a.Status;
                vd.VolunteerId = a.VolunteerId;
                vd.ActionId = a.ActionId;
                VoluntaryActionDtoU vDA = new VoluntaryActionDtoU();
                VolunteerDtoU vDt = new VolunteerDtoU();

                var V = _IS.GetDataOfInvite(a.VolunteerId);
                var A = _IS.GetActionV(a.ActionId);
                foreach (VoluntaryAction Ac in A)
                {
                    
                    vDA.ActionId = Ac.ActionId;
                    vDA.Name = Ac.Name;
                    vDA.StartDate = Ac.StartDate;
                    vDA.EndDate = Ac.EndDate;
                    vd.Actions.Add(vDA);
                }

                foreach (Volunteer v in V)
                {
                    
                    vDt.VolunteerId = v.Id;
                    vDt.UserName = v.UserName;
                    vDt.UserEmail = v.Email;
                    vd.Volunteers.Add(vDt);
                }
                vaDtos.Add(vd);
                
            }

            
            return vaDtos;


                    }

        // POST: api/Invitation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Invitation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Invitation/5
        public void Delete(int id)
        {
        }
    }
}
