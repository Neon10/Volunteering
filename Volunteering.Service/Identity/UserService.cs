using Volunteering.Data;

namespace Volunteering.Service.Identity
{
    public class UserService
    {
        public ApplicationUserManager UserManager { get; set; }
        public UserService()
        {
            ApplicationUserStore store = new ApplicationUserStore(new AppContext());
            UserManager = new ApplicationUserManager(store);
        }



    }
}
