using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Service.Pattern;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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







        public void RegisterUser(string name, string email, string password, EAccountType role, ref IdentityResult result)
        {

            if (role == EAccountType.Volunteer)
            {
                Volunteer v = new Volunteer { Name = name, Email = email, UserName = email };
                result = UserManager.Create(v, password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(v.Id, role.ToString());
                    SignInManager.SignIn(v, isPersistent: false, rememberBrowser: false);
                }
            }

            else if (role == EAccountType.Ngo)
            {
                Ngo n = new Ngo() { Name = name, Email = email, UserName = email };
                result = UserManager.Create(n, password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(n.Id, role.ToString());
                    SignInManager.SignIn(n, isPersistent: false, rememberBrowser: false);
                }
            }

        }


        public string GetUserRole(ApplicationUser user)
        {

            var roles = _userManager.GetRoles(user.Id);


            if (roles != null)
            {
                return roles.First();
            }
            else
            {
                return "RoleNotFound";
            }

        }

        public string GetCurrentUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }

        public IEnumerable<Ngo> GetAllNgos()
        {
            var allUsers = GetAll().ToList();

            ICollection<Ngo> allNgos = new List<Ngo>();

            foreach (ApplicationUser appUser in allUsers)
            {
                if (GetUserRole(appUser).Equals("Ngo"))
                {
                    allNgos.Add(appUser as Ngo);
                }
            }

            return allNgos;
        }


        public IEnumerable<Volunteer> GetAllVolunteers()
        {
            var allUsers = GetAll().ToList();

            ICollection<Volunteer> allVolunteers = new List<Volunteer>();

            foreach (ApplicationUser appUser in allUsers)
            {
                if (GetUserRole(appUser).Equals("Volunteer"))
                {
                    allVolunteers.Add(appUser as Volunteer);
                }
            }

            return allVolunteers;
        }


        public string GetAppUserId()
        {

            var usr = UserManager.FindById(HttpContext.Current.User.Identity.GetUserId());

            return usr.Id;
        }


    }



}
