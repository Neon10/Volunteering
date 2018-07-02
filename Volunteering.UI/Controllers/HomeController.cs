using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Volunteering.Domain.Entities;
using Volunteering.Service;

namespace Volunteering.UI.Controllers
{
    public class HomeController : Controller
    {
        VoluntaryActionService vas = new VoluntaryActionService();


        // GET: Home
        public ActionResult Index()
        {
            
                string markers = "[";
                List<VoluntaryAction> actions = new List<VoluntaryAction>();
                actions = vas.GetAll().ToList();
                foreach (VoluntaryAction sdr in actions)
                {
                    markers += "{";
                    markers += string.Format("'Address': '{0}',", sdr.Address);
                    markers += string.Format("'lat': '{0}',", vas.GetLatitude(sdr.Address,"true"));
                    markers += string.Format("'lng': '{0}',", vas.GetLongitude(sdr.Address,"true"));
                    //markers += string.Format("'description': '{0}'", sdr.Description);
                    markers += "},";
                }


            string idUser = User.Identity.GetUserId();

            InvitationService IS = new InvitationService();

            markers += "];";
            ViewBag.Markers = markers;
            ViewBag.countV = IS.countV(idUser);
            return View();
            }


          


        public string AddUser()
        {
            AppService s = new AppService();
            s.TestContext();


            //UserService us = new UserService();
            //var user = new ApplicationUser
            //{
            //    UserName = "TestUser",
            //    Email = "TestUser@test.com"
            //};


            //var result = await us.UserManager.CreateAsync(user);
            //if (!result.Succeeded)
            //{
            //    return result.Errors.First();
            //}
            return "User Added";
        }


    }
}