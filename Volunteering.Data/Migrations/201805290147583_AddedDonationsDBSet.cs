namespace Volunteering.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDonationsDBSet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donations", "CampaignId", "dbo.FundraisingCampaigns");
            DropIndex("dbo.Donations", new[] { "CampaignId" });
            RenameColumn(table: "dbo.Donations", name: "CampaignId", newName: "Campaign_CampaignId");
            DropPrimaryKey("dbo.Donations");
            AddColumn("dbo.FundraisingCampaigns", "Name", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.FundraisingCampaigns", "Description", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.FundraisingCampaigns", "StartDate", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.FundraisingCampaigns", "EndDate", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.FundraisingCampaigns", "TargetAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Donations", "DonationId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Donations", "Amount", c => c.Int(nullable: false));
            AlterColumn("dbo.Donations", "Campaign_CampaignId", c => c.Int());
            AddPrimaryKey("dbo.Donations", "DonationId");
            CreateIndex("dbo.Donations", "Campaign_CampaignId");
            AddForeignKey("dbo.Donations", "Campaign_CampaignId", "dbo.FundraisingCampaigns", "CampaignId");
            DropColumn("dbo.Donations", "VolunteerId");
            DropColumn("dbo.Donations", "Somme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Donations", "Somme", c => c.Int(nullable: false));
            AddColumn("dbo.Donations", "VolunteerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Donations", "Campaign_CampaignId", "dbo.FundraisingCampaigns");
            DropIndex("dbo.Donations", new[] { "Campaign_CampaignId" });
            DropPrimaryKey("dbo.Donations");
            AlterColumn("dbo.Donations", "Campaign_CampaignId", c => c.Int(nullable: false));
            DropColumn("dbo.Donations", "Amount");
            DropColumn("dbo.Donations", "DonationId");
            DropColumn("dbo.FundraisingCampaigns", "TargetAmount");
            DropColumn("dbo.FundraisingCampaigns", "EndDate");
            DropColumn("dbo.FundraisingCampaigns", "StartDate");
            DropColumn("dbo.FundraisingCampaigns", "Description");
            DropColumn("dbo.FundraisingCampaigns", "Name");
            AddPrimaryKey("dbo.Donations", new[] { "VolunteerId", "CampaignId", "Somme" });
            RenameColumn(table: "dbo.Donations", name: "Campaign_CampaignId", newName: "CampaignId");
            CreateIndex("dbo.Donations", "CampaignId");
            AddForeignKey("dbo.Donations", "CampaignId", "dbo.FundraisingCampaigns", "CampaignId", cascadeDelete: true);
        }
    }
}
