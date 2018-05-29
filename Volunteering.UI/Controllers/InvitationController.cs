using System.Web.Mvc;
using Volunteering.Service;
using Volunteering.Service.Identity;

namespace Volunteering.UI.Controllers
{

    public class InvitationController : Controller
    {

        InvitationService invtService = new InvitationService();
        UserService usrService = new UserService();

        //ref Current user
        //HttpContext.User.Identity.GetUserId();


        // GET: Invitation
        public ActionResult Index()
        {


            return View(invtService.GetAll());
        }

        // GET: Invitation/Details/5
        public ActionResult Details(int id)
        {
            return View(invtService.GetById(id));
        }

        // GET: Invitation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invitation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invitation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Invitation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invitation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Invitation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
