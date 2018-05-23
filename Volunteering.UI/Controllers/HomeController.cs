using System.Web;
using System.Web.Mvc;
using Volunteering.Service;

namespace Volunteering.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
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