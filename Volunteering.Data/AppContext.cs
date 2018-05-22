using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System.Data.Entity;
using Volunteering.Domain.Entities;

namespace Volunteering.Data
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
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

        public static AppContext Create()
        {
            return new AppContext();
        }



        public DbSet<Action> Actions { get; set; }
    }
}
