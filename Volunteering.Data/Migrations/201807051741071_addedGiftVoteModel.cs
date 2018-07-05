namespace Volunteering.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedGiftVoteModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImageUrl", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "Solde", c => c.Int(nullable: false));
            AddColumn("dbo.VoluntaryActions", "Long", c => c.Double(nullable: false));
            AddColumn("dbo.VoluntaryActions", "Lat", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VoluntaryActions", "Lat");
            DropColumn("dbo.VoluntaryActions", "Long");
            DropColumn("dbo.AspNetUsers", "Solde");
            DropColumn("dbo.AspNetUsers", "ImageUrl");
        }
    }
}
