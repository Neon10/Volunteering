using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Enums;
using Volunteering.Service;
using Volunteering.Service.Identity;

namespace Volunteering.UI.Controllers
{
    [Authorize(Roles = "Ngo")]
    public class VoluntaryActionController : Controller
    {

        private VoluntaryActionService vas = new VoluntaryActionService();
        private  UserService us = new UserService();
        [AllowAnonymous]
        // GET: VoluntaryAction
        public ActionResult Index()
        {

            return View(vas.GetAll());
          
           
        }
        [AllowAnonymous]
        // GET: VoluntaryAction/Details/5
        public ActionResult Details(int id)
        {
            return View(vas.GetById(id));
        }

        // GET: VoluntaryAction/Create
        //[Authorize(Roles = "Ngo")]
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoluntaryAction/Create
        [HttpPost]
        //[Authorize(Roles = "Ngo")]
        public ActionResult Create(VoluntaryAction V)
        {
            VoluntaryAction v = new VoluntaryAction();
            //try
            //{
                v.Name = V.Name;
                v.Address = V.Address;
                v.Description = V.Description;
                v.StartDate = V.StartDate;
                v.EndDate = V.EndDate;
                v.MaxVolunteers = V.MaxVolunteers;
                v.ActionType = V.ActionType;
                 v.CreatorNgoId = User.Identity.GetUserId();
            vas.Add(v);
                vas.Commit();


                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: VoluntaryAction/Edit/5
        //[Authorize(Roles = "Ngo")]
        public ActionResult Edit(int id)
        {
            return View(vas.GetById(id));
        }

        // POST: VoluntaryAction/Edit/5
        //[Authorize(Roles = "Ngo")]
        [HttpPost]
        public ActionResult Edit(int id, VoluntaryAction V)
        {
            VoluntaryAction action = new VoluntaryAction();
            action = vas.GetById(V.ActionId);

            try
            {
                action.Name = V.Name;
                action.Address = V.Address;
                action.Description = V.Description;
                action.StartDate = V.StartDate;
                action.EndDate = V.EndDate;
                action.MaxVolunteers = V.MaxVolunteers;
                action.ActionType = V.ActionType;
                vas.Commit();
                //return View();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //[Authorize(Roles = "Ngo")]
        // GET: VoluntaryAction/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                vas.Delete(vas.GetById(id));
                vas.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: VoluntaryAction/Delete/5
        [HttpPost]
        //[Authorize(Roles = "Ngo")]
        public ActionResult Delete(int id, VoluntaryAction V)
        {

                return View();
            
        }

        [AllowAnonymous]
        // GET: VoluntaryAction/ListParticipants/5
        public ActionResult ListParticipants(int id)
        {


            IEnumerable<Volunteer> participants = new List<Volunteer>();
            participants = vas.GetById(id).Participants;
            ViewBag.participants = participants;

            return View(vas.GetById(id));
        }
    }
}
