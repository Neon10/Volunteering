using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Volunteering.Domain.Entities;
using Volunteering.Service;
using Volunteering.Service.Identity;

namespace Volunteering.UI.Controllers
{
    [Authorize]
    public class DiscussionController : Controller
    {
        private readonly DiscussionService ds = new DiscussionService();
        private readonly UserService us = new UserService();


        // GET: Discussion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Discussion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Discussion/Create
        public ActionResult CreateNewDiscussion()
        {
            return View();
        }

        // POST: Discussion/Create
        [HttpPost]
        public ActionResult CreateNewDiscussion(Discussion D, string Email)
        {
            Discussion d = new Discussion();

            d.Title = D.Title;
            d.Content = D.Content;
            d.SenderId = User.Identity.GetUserId();
            if (us.UserManager.FindByEmail(Email) !=null)
            {
                d.RecipientId = us.UserManager.FindByEmail(Email).Id;
            }
            else
            {
                return View();
            }


            ds.Add(d);
            ds.Commit();

            return View();

        }

        // GET: Discussion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Discussion/Edit/5
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

        // GET: Discussion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Discussion/Delete/5
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
