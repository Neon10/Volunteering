using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Volunteering.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Discussions = new List<Discussion>();
        }

        public string Name { get; set; }

        public ICollection<Discussion> Discussions { get; set; }

    }
}
