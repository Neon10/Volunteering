using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Web;
using Volunteering.Data;
using Volunteering.Domain.Entities;

namespace Volunteering.Service.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {



        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
            store = new ApplicationUserStore(HttpContext.Current.GetOwinContext().Get<AppContext>());


        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            //var store = new UserStore<ApplicationUser>(context.Get<AppContext>());
            //var manager = new ApplicationUserManager(store);

            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<AppContext>()));

            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = false,
            };


            return manager;
        }



    }
}
