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
using GoogleMaps.LocationServices;
using Volunteering.Domain.Dtos;

namespace Volunteering.UI.Controllers_Api
{
    [RoutePrefix("api/Action")]
    public class VoluntaryActionController : ApiController
    {
        private VoluntaryActionService vas = new VoluntaryActionService();
        [Route("getActions")]
        [ResponseType(typeof(VoluntaryAction))]
        // GET: api/Action
        public List<VoluntaryActionDto> GetAllActions()
        {
            IQueryable actions = vas.GetAllActions();
            List<VoluntaryActionDto> vaDtos = new List<VoluntaryActionDto>();
           

            foreach (VoluntaryAction a in actions)
            {
                VoluntaryActionDto vd = new VoluntaryActionDto();
                vd.ActionId = a.ActionId;
                vd.Name = a.Name;
                vd.Address = a.Address;
                vd.Description = a.Description;
                vd.StartDate = a.StartDate;
                vd.EndDate = a.EndDate;
                vd.ActionType = a.ActionType;
                vd.MaxVolunteers = a.MaxVolunteers;
                vd.CreatorNgoId = a.CreatorNgoId;

                foreach (Volunteer v in a.Participants)
                {
                    UserDto vDt = new UserDto();
                    vDt.Id = v.Id;
                    vDt.Name = v.Name;
                    vDt.Email = v.Email;
                    vDt.PhoneNumber = v.PhoneNumber;
                    vDt.Role = "Volunteer";
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
        [Route("getPoint")]
        // GET: api/VoluntaryAction/5
        public MapPoint Point()
        {
            MapPoint m = new MapPoint();
            //var address = "Tunis";
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress("tunis");


            //m.Latitude= point.Latitude;
            //m.Longitude = point.Longitude;
            return point;
        }

    }
}
