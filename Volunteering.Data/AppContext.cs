using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System.Data.Entity;
using Volunteering.Data.Conventions;
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

            DbModelBuilder model = new DbModelBuilder();
            model.Conventions.Add(new DateTime2Convention());

        }



        public static AppContext Create()
        {
            return new AppContext();
        }



        public DbSet<FundraisingCampaign> Campaigns { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<VoluntaryAction> VoluntaryActions { get; set; }


    }
}
