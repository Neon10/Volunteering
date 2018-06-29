using Microsoft.AspNet.Identity;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Volunteering.Domain.Entities;
using Volunteering.Service;
using Volunteering.Service.Identity;

namespace Volunteering.UI.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        // GET: Manage
        public ActionResult Index()
        {
            string  idUser=  User.Identity.GetUserId();
          
          InvitationService IS = new InvitationService();

            IEnumerable<Invitation> I = IS.GetUnansweredInvites(idUser);
            //IEnumerable<Invitation> IA = IS.GetAcceptedInvites(idUser);
            //  IEnumerable<VoluntaryAction> A;

            foreach (var item in I)
            {
                ViewBag.Invit = item.InvitationId;
                 //ViewBag.A = IS.GetActionV(item.ActionId);

                            
               

            }
            ViewBag.A = IS.ActionOfCurrentVol(idUser);

           // ViewBag.count = I;

            ViewBag.IA = I;
            ViewBag.countV = IS.countV(idUser);


            return View();
        }
    }
}