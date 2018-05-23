using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using System.Web;
using Volunteering.Data;
using Volunteering.Domain.Entities;
using Volunteering.Service.Identity;

namespace Volunteering.Service
{
    public class AppService
    {


        // TODO Remove this Method
        public void TestContext()
        {
            IOwinContext c = new OwinContext();
            Volunteer v = new Volunteer { Email = "123@123.fr", UserName = "123456" };
            var cox = HttpContext.Current.GetOwinContext().Get<AppContext>();

            // c.Get<AppContext>().Users.Add(v);

        }


        public static void OwinInit(IAppBuilder app)
        {

            app.CreatePerOwinContext(AppContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

        }

        public static void InitManagers()
        {
            //TODO Extract Managers initialisation Here
        }


    }
}
