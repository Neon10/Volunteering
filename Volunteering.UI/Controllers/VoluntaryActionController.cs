using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Enums;
using Volunteering.Service;

namespace Volunteering.UI.Controllers
{
    public class VoluntaryActionController : Controller
    {

        private VoluntaryActionService vas = new VoluntaryActionService();

        // GET: VoluntaryAction
        public ActionResult Index()
        {

            return View(vas.GetAll());
        }

        // GET: VoluntaryAction/Details/5
        public ActionResult Details(int id)
        {
            InvitationService I = new InvitationService();

            IEnumerable<Volunteer> Vol = I.GetInvites();
           IEnumerable<Invitation> INVITES = I.GetAllInvites();
            IEnumerable <Invitation> IA= I.GetInvitOfSelectedAction(id);

            foreach (var item in IA)
            {

                ViewBag.SiA = item.VolunteerId;
               
            }

            ViewBag.actionId = id;
            ViewBag.invitations = INVITES;
            ViewBag.VolNotInvited = Vol;
            ViewBag.VolInvited = I.VolInvited(id);

             return View(vas.GetById(id));
            

        }
        

        // GET: VoluntaryAction/Create
        [Authorize(Roles = "Ngo")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: VoluntaryAction/Create
        [HttpPost]
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
        public ActionResult Edit(int id)
        {
            return View(vas.GetById(id));
        }

        // POST: VoluntaryAction/Edit/5
        [Authorize(Roles ="Ngo")]
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
                vas.Add(action);
                vas.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public VoluntaryAction GetA(int id, VoluntaryAction V)
        {
            VoluntaryAction action = new VoluntaryAction();
            return action = vas.GetById(V.ActionId);
        }

        // GET: VoluntaryAction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VoluntaryAction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, VoluntaryAction V)
        {
            try
            {
                vas.Delete(vas.GetById(V.ActionId));
                vas.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
