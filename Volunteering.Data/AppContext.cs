using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Volunteering.Domain.Entities;

namespace Volunteering.Data
{

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AppContext : IdentityDbContext<ApplicationUser>
    {
        public AppContext() : base("MyContext")
        {
            //=============================================//
            //   ------ Initializing Roles DataBase -------//
            //=============================================//

            //IdentityRole adminRole = new IdentityRole(EAccountType.Administrator.ToString());
            //IdentityRole ngoRole = new IdentityRole(EAccountType.Ngo.ToString());
            //IdentityRole volunteerRole = new IdentityRole(EAccountType.Volunteer.ToString());

            //Roles.Add(adminRole);
            //Roles.Add(ngoRole);
            //Roles.Add(volunteerRole);

        }



        public DbSet<Action> Actions { get; set; }

    }
}
