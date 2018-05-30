namespace Volunteering.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingaddressattribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VoluntaryActions", "Address", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VoluntaryActions", "Address");
        }
    }
}
