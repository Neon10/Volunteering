using Owin;
using Volunteering.Data;
using Volunteering.Service.Identity;

namespace Volunteering.Service
{
    public static class Startup
    {
        //TODO Rename class 
        public static void OwinInit(IAppBuilder app)
        {

            app.CreatePerOwinContext(AppContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

        }

    }
}
