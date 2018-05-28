using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using Volunteering.Data;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Enums;

namespace Volunteering.Service.Identity
{

    // TODO Refactor UserService Class 

    public class UserService
    {
        // public ApplicationUserManager UserManager { get; set; }


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }


        public UserService()
        {
            ApplicationUserStore store = new ApplicationUserStore(new AppContext());
            UserManager = new ApplicationUserManager(store);
        }


        public void RegisterUser(string email, string password, EAccountType role, ref IdentityResult result)
        {

            if (role == EAccountType.Volunteer)
            {
                Volunteer v = new Volunteer { Email = email, UserName = email };
                result = UserManager.Create(v, password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(v.Id, role.ToString());
                    SignInManager.SignIn(v, isPersistent: false, rememberBrowser: false);
                }
            }

            else if (role == EAccountType.Ngo)
            {
                Ngo n = new Ngo() { Email = email, UserName = email };
                result = UserManager.Create(n, password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(n.Id, role.ToString());
                    SignInManager.SignIn(n, isPersistent: false, rememberBrowser: false);
                }
            }

        }






    }
}
