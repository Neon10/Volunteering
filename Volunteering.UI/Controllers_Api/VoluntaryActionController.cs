using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Volunteering.Domain.Entities;
using Volunteering.Service;
using System.Data.Entity;
using System.Web.Http.Description;
using Volunteering.Domain.Dtos;

namespace Volunteering.UI.Controllers_Api
{
    [RoutePrefix("api/Action")]
    public class VoluntaryActionController : ApiController
    {
        private VoluntaryActionService vas = new VoluntaryActionService();
        [Route("getActions")]
        [ResponseType(typeof(VoluntaryAction))]
        // GET: api/Account
        public List<VoluntaryActionDto> GetAllUsersTest()
        {
            IQueryable actions = vas.GetAllActions();
            List<VoluntaryActionDto> vaDtos = new List<VoluntaryActionDto>();
           

            foreach (VoluntaryAction a in actions)
            {
                VoluntaryActionDto vd = new VoluntaryActionDto();
                vd.ActionId = a.ActionId;
                vd.Name = a.Name;
                foreach (Volunteer v in a.Participants)
                {
                    VolunteerDto vDt = new VolunteerDto();
                    vDt.VolunteerId = v.Id;
                    vDt.UserName = v.UserName;
                    vDt.UserEmail = v.Email;
                    vd.Participants.Add(vDt);
                }
                vaDtos.Add(vd);
                   
            }



            return vaDtos;
           

        }



        [Route("getAction")]
        // GET: api/VoluntaryAction/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VoluntaryAction
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VoluntaryAction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VoluntaryAction/5
        public void Delete(int id)
        {
        }

       
    }
}
