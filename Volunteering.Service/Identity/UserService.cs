using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Service.Pattern;
using System.Linq;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using Volunteering.Data;
using Volunteering.Data.Infrastructure;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Enums;

namespace Volunteering.Service.Identity
{

    // TODO Refactor UserService Class 

    public class UserService : Service<ApplicationUser>
    {
        // public ApplicationUserManager UserManager { get; set; }

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly AppContext _context = new AppContext();

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


        public UserService() : base(ut)
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


        public string GetUserRole(string userId)
        {
            ApplicationUser u = _userManager.FindById(userId);
            
            return Roles.GetRolesForUser(u.UserName).First();
        }


    }
}
