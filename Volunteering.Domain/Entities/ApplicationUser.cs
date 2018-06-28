using Microsoft.AspNet.Identity.EntityFramework;


namespace Volunteering.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

    }
}
