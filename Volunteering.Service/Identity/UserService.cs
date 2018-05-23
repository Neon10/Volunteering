using Volunteering.Data;

namespace Volunteering.Service.Identity
{

    // TODO Refactor UserService Class 

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
