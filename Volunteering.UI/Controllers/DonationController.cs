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
    public class DonationController : Controller
    {

        //===========================//
        //--------- INIT ------------//
        //===========================//

        private readonly DonationService donService = new DonationService();


        //===========================//
        //--------- VIEW ----------  //
        //===========================//

        // GET: Donation
        public ActionResult Index()
        {
            return View(donService.GetAll());

        }

        // GET: Donation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //===========================//
        //--------- CREATE ----------//
        //===========================//

        // GET: Donation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donation/Create
        [HttpPost]
        public ActionResult Create(Donation Don)
        {
            Console.WriteLine(Don.CampaignId);
            Console.WriteLine(Don.Amount);
            return View();



            //try
            //{
            //    UserService us = new UserService();


            //    Donation don = new Donation();
            //    Volunteer volunteer = us.UserManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()) as Volunteer;
            //    FundraisingCampaign fund = new FundraisingCampaign();


            //    don.Amount = Don.Amount;
            //    don.Volunteer = volunteer;
            //    don.Campaign = fund;

            //    donService.Add(don);
            //    donService.Commit();




            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        //===========================//
        //--------- Edit ------------//
        //===========================//

        // GET: Donation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Donation/Edit/5
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
        //--------- DELETE ----------//
        //===========================//

        // GET: Donation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Donation/Delete/5
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

        //===========================//
        //--------- DONATE ----------//
        //===========================//

        // GET: Donation/Create
        public ActionResult Donate()
        {
            return View();
        }

        // POST: Donation/Create
        [HttpPost]
        public ActionResult Donate(FormCollection collection)
        {
            try
            {
                Donation don = new Donation();



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
