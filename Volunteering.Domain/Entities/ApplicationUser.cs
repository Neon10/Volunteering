using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Volunteering.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Discussions = new List<Discussion>();
            ImageUrl = "https://www.w3schools.com/w3images/avatar2.png";
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int Solde { get; set; }

        public ICollection<Discussion> Discussions { get; set; }

    }
}
