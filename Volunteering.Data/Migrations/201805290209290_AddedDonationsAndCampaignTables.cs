namespace Volunteering.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDonationsAndCampaignTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FundraisingCampaigns",
                c => new
                    {
                        CampaignId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        TargetAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CampaignId);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Campaign_CampaignId = c.Int(),
                        Volunteer_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.DonationId)
                .ForeignKey("dbo.FundraisingCampaigns", t => t.Campaign_CampaignId)
                .ForeignKey("dbo.AspNetUsers", t => t.Volunteer_Id)
                .Index(t => t.Campaign_CampaignId)
                .Index(t => t.Volunteer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "Volunteer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Donations", "Campaign_CampaignId", "dbo.FundraisingCampaigns");
            DropIndex("dbo.Donations", new[] { "Volunteer_Id" });
            DropIndex("dbo.Donations", new[] { "Campaign_CampaignId" });
            DropTable("dbo.Donations");
            DropTable("dbo.FundraisingCampaigns");
        }
    }
}
