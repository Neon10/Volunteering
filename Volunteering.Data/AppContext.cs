using System.Data.Entity;
using Volunteering.Domain.Entities;

namespace Volunteering.Data
{

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AppContext : DbContext
    {
        public AppContext() : base("MyContext")
        {

        }



        public DbSet<Action> Actions { get; set; }

    }
}
