using System.Web.Mvc;
using Volunteering.Service;

namespace Volunteering.UI.Controllers
{
    public class FundraisingCampaignController : Controller
    {

        //===========================//
        //--------- INIT ----------
        //===========================//

        private readonly FundraisingCampaignService fcService = new FundraisingCampaignService();



        //===========================//
        //--------- VIEW ----------
        //===========================//

        // GET: FundraisingCampaign
        public ActionResult Index()
        {

            return View(fcService.GetAll());
        }


        // GET: FundraisingCampaign/Details/5
        public ActionResult Details(int id)
        {

            return View(fcService.GetById(id));
        }

        //===========================//
        //--------- CREATE ----------
        //===========================//

        // GET: FundraisingCampaign/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: FundraisingCampaign/Create
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

        //===========================//
        //---------- EDIT ----------
        //===========================//

        // GET: FundraisingCampaign/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FundraisingCampaign/Edit/5
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

        //===========================//
        //--------- DELETE ----------
        //===========================//

        // GET: FundraisingCampaign/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FundraisingCampaign/Delete/5
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
