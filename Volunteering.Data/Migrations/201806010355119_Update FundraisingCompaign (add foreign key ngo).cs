namespace Volunteering.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFundraisingCompaignaddforeignkeyngo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FundraisingCampaigns", "OwnerNgo_Id", c => c.String(maxLength: 128, storeType: "nvarchar"));
            CreateIndex("dbo.FundraisingCampaigns", "OwnerNgo_Id");
            AddForeignKey("dbo.FundraisingCampaigns", "OwnerNgo_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FundraisingCampaigns", "OwnerNgo_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FundraisingCampaigns", new[] { "OwnerNgo_Id" });
            DropColumn("dbo.FundraisingCampaigns", "OwnerNgo_Id");
        }
    }
}
