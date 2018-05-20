using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Volunteering.Domain.Entities;
using Volunteering.Service.Identity;

namespace Volunteering.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }



        public async Task<string> AddUser()
        {
            UserService us = new UserService();
            var user = new ApplicationUser
            {
                UserName = "TestUser",
                Email = "TestUser@test.com"
            };


            var result = await us.UserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return result.Errors.First();
            }
            return "User Added";
        }


    }
}