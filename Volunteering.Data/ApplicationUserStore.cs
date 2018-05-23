using Microsoft.AspNet.Identity.EntityFramework;
using Volunteering.Domain.Entities;

namespace Volunteering.Data
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {

        public ApplicationUserStore(AppContext context) : base(context)
        {
        }
    }
}
