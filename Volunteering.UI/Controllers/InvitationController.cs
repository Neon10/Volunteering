using System.Collections.Generic;
using System.Web.Mvc;
using Volunteering.Domain.Entities;
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
        //[HttpGet]
        [HttpPost]
        //[Route("Invitation/{idV}/{idA}")]
        public ActionResult InvitCreate(string idV, int idA)
        {
            //try
            //{
            Invitation I = new Invitation();
            InvitationService IS = new InvitationService();
            
            
            I.Status = Domain.Enums.InvitationStatus.Unanswered;
            I.ActionId = idA;
            I.VolunteerId = idV;
           if(IS.NumberOfInvitesIfExist(idA, idV) == 0)
                    invtService.Add(I);
           
                    try
                    {
                        invtService.Commit();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }

                        //           }
                        //           catch
                        //           {
                        //return View();
                        //           }
                    
                
            }
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult InvitupdateA( int idI, FormCollection collection)
        {
            //try
            //{

            foreach (var item in invtService.ForUpdateInv(idI))
            {
                item.Status = Domain.Enums.InvitationStatus.Accepted;
                invtService.Update(item);

            }
            try
            {
                invtService.Commit();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }


            }


            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult InvitupdateR(int idI)
        {
            //try
            //{

            
            foreach (var item in invtService.ForUpdateInv(idI))
            {
                item.Status = Domain.Enums.InvitationStatus.Refused;
                invtService.Update(item);
                
            }
            try
            {
                invtService.Commit();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }


            }

            
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }

        public ActionResult DeleteInvit( string idV, int idA)
        {
            //try
            //{
           

            var x =  invtService.FordeleteInv(idA, idV);

            foreach (Invitation i in x)
            {
                invtService.Delete(i);
            }

            try
            {
                invtService.Commit();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }

                //           }
                //           catch
                //           {
                //return View();
                //           }
            }
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
        // POST: Invitation/Create
        //[HttpPost]
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
