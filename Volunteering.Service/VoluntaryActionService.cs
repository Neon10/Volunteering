using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using GoogleMaps.LocationServices;
using Microsoft.AspNet.Identity;
using Service.Pattern;
using Volunteering.Data;
using Volunteering.Data.Infrastructure;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Enums;
using Volunteering.Service.Identity;


namespace Volunteering.Service
{
    public class VoluntaryActionService : Service<VoluntaryAction>
    {
        
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        private static AppContext _context = new AppContext();
        private readonly UserService us = new UserService();

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

        public VoluntaryAction GetActionByIdEager(int id)
        {
            return _context.VoluntaryActions.Include(a => a.Participants).FirstOrDefault();

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
        public void Participate(int actionId, string userId)
        {

            if (!IsParticipated(actionId, userId))
            {
                Volunteer v = ut.GetRepository<ApplicationUser>().GetById(userId) as Volunteer;
                VoluntaryAction a = ut.GetRepository<VoluntaryAction>().GetById(actionId);
                a.Participants.Add(v);
                Update(a);
                Commit();
            }
            else
            {
                Volunteer v = ut.GetRepository<ApplicationUser>().GetById(userId) as Volunteer;

                VoluntaryAction a = GetActionByIdEager(actionId);
                Volunteer vr = a.Participants.First(x => x.Id == userId);
                a.Participants.Remove(vr);
                _context.VoluntaryActions.AddOrUpdate(a);
                _context.SaveChanges();
                Commit();

            }

        }
        public bool IsParticipated(int actionId ,string userId)
        {

           VoluntaryAction a= GetActionByIdEager(actionId);
           Volunteer v = us.UserManager.FindById(userId) as Volunteer;

            return a.Participants.Any(p=>p.Id==userId);
        }



        public double GetLat(string address)
        {

            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(address);
            return point.Latitude;
            //return 37.21706989634869;

        }

        public double GetLong(string address)
        {
            
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(address);
            //return 10.059717490333583;
            return point.Longitude;
            

        }


        public string GetLongitude(string address, string sensor)
        {
            string urlAddress = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + HttpUtility.UrlEncode(address) + "&sensor=" + sensor;
            string returnValue = "";
            try
            {
                XmlDocument objXmlDocument = new XmlDocument();
                objXmlDocument.Load(urlAddress);
                XmlNodeList objXmlNodeList = objXmlDocument.SelectNodes("/GeocodeResponse/result/geometry/location");
                foreach (XmlNode objXmlNode in objXmlNodeList)
                {
                    // GET LONGITUDE 
                    returnValue = objXmlNode.ChildNodes.Item(0).InnerText;

                    //// GET LATITUDE 
                    //returnValue += "," + objXmlNode.ChildNodes.Item(1).InnerText;
                }
            }
            catch
            {
                // Process an error action here if needed  
            }
            return returnValue;
        }



        public string GetLatitude(string address, string sensor)
        {
            string urlAddress = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + HttpUtility.UrlEncode(address) + "&sensor=" + sensor;
            string returnValue = "";
            try
            {
                XmlDocument objXmlDocument = new XmlDocument();
                objXmlDocument.Load(urlAddress);
                XmlNodeList objXmlNodeList = objXmlDocument.SelectNodes("/GeocodeResponse/result/geometry/location");
                foreach (XmlNode objXmlNode in objXmlNodeList)
                {
                    // GET LONGITUDE 
                    //returnValue = objXmlNode.ChildNodes.Item(0).InnerText;

                    // GET LATITUDE 
                    returnValue += "," + objXmlNode.ChildNodes.Item(1).InnerText;
                }
            }
            catch
            {
                // Process an error action here if needed  
            }
            return returnValue;
        }



    }
}
