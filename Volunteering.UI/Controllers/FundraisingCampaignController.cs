using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Volunteering.Domain.Entities;
using Volunteering.Service;
using Volunteering.Service.Identity;

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
        [Authorize(Roles = "Ngo")]
        public ActionResult Create(FormCollection collection, FundraisingCampaign Fund)
        {


            
                UserService us = new UserService();


                FundraisingCampaign fund = new FundraisingCampaign() ;
                Ngo ngo = us.UserManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()) as Ngo;



                fund.Name = Fund.Name;
                fund.Description = Fund.Description;
                fund.StartDate = Fund.StartDate;
                fund.EndDate = Fund.EndDate;
                fund.TargetAmount = Fund.TargetAmount;
            //fund.OwnerNgo = new Ngo {Email = "3a3ou3eh3ouuu3@3eh.hahaha", PasswordHash = "eeeeeeee", UserName = "3a3ou3eh3ouuu3@3eh.hahaha" };
                fund.OwnerNgo = ngo;
                fcService.Add(fund);
                fcService.Commit();

                return RedirectToAction("Index");
           
            
        }

        //===========================//
        //---------- EDIT ----------
        //===========================//

        // GET: FundraisingCampaign/Edit/5
        public ActionResult Edit(int id)
        {
            return View(fcService.GetById(id));
        }

        // POST: FundraisingCampaign/Edit/5
        [HttpPost]
        [Authorize(Roles = "Ngo")]
        public ActionResult Edit(int id, FormCollection collection, FundraisingCampaign Fund)
        {
            try
            {
                FundraisingCampaign fundation = new FundraisingCampaign();
                fundation = fcService.GetById(Fund.CampaignId);

                fundation.Name = Fund.Name;
                fundation.Description = Fund.Description;
                fundation.StartDate = Fund.StartDate;
                fundation.EndDate = Fund.EndDate;
                fundation.TargetAmount = Fund.TargetAmount;
                fcService.Commit();

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
        public ActionResult Delete(int id, FormCollection collection, FundraisingCampaign Fund)
        {
            try
            {
                // TODO: Add delete logic here
                FundraisingCampaign test = new FundraisingCampaign();

                
                fcService.Delete(fcService.GetById(id));
                fcService.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //====================================================//
        //--------- Get FundraisingCompaign By Ngo  ----------//
        //=================================================== //

        
        // GET: FundraisingCampaign/ngoCompaigns
        public ActionResult NgoCompaigns()
        {

            return View(fcService.FundraisingCompaignByNgo());
        }






    }
}
