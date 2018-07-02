using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Volunteering.UI.Controllers
{
    public class tessstController : Controller
    {
        // GET: tessst
        public ActionResult Index()
        {
            return View();
        }

        // GET: tessst/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: tessst/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tessst/Create
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

        // GET: tessst/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: tessst/Edit/5
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

        // GET: tessst/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: tessst/Delete/5
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
