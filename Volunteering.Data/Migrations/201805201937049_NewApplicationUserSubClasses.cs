namespace Volunteering.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewApplicationUserSubClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
    }
}
