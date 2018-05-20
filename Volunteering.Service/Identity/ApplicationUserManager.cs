using Microsoft.AspNet.Identity;
using Volunteering.Data;
using Volunteering.Domain.Entities;

namespace Volunteering.Service.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {



        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
            store = new ApplicationUserStore(new AppContext());
        }



    }
}
