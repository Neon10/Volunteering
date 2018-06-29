namespace Volunteering.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyInvit : DbMigration
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
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        InvitationId = c.Int(nullable: false, identity: true),
                        ActionId = c.Int(nullable: false),
                        VolunteerId = c.String(maxLength: 128, storeType: "nvarchar"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvitationId)
                .ForeignKey("dbo.VoluntaryActions", t => t.ActionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.VolunteerId)
                .Index(t => t.ActionId)
                .Index(t => t.VolunteerId);
            
            CreateTable(
                "dbo.VoluntaryActions",
                c => new
                    {
                        ActionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        MaxVolunteers = c.Int(nullable: false),
                        ActionType = c.Int(nullable: false),
                        CreatorNgo_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ActionId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorNgo_Id)
                .Index(t => t.CreatorNgo_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.VoluntaryActionVolunteers",
                c => new
                    {
                        VoluntaryAction_ActionId = c.Int(nullable: false),
                        Volunteer_Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.VoluntaryAction_ActionId, t.Volunteer_Id })
                .ForeignKey("dbo.VoluntaryActions", t => t.VoluntaryAction_ActionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Volunteer_Id, cascadeDelete: true)
                .Index(t => t.VoluntaryAction_ActionId)
                .Index(t => t.Volunteer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Invitations", "VolunteerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invitations", "ActionId", "dbo.VoluntaryActions");
            DropForeignKey("dbo.VoluntaryActionVolunteers", "Volunteer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VoluntaryActionVolunteers", "VoluntaryAction_ActionId", "dbo.VoluntaryActions");
            DropForeignKey("dbo.VoluntaryActions", "CreatorNgo_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Donations", "Volunteer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Donations", "Campaign_CampaignId", "dbo.FundraisingCampaigns");
            DropIndex("dbo.VoluntaryActionVolunteers", new[] { "Volunteer_Id" });
            DropIndex("dbo.VoluntaryActionVolunteers", new[] { "VoluntaryAction_ActionId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.VoluntaryActions", new[] { "CreatorNgo_Id" });
            DropIndex("dbo.Invitations", new[] { "VolunteerId" });
            DropIndex("dbo.Invitations", new[] { "ActionId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Donations", new[] { "Volunteer_Id" });
            DropIndex("dbo.Donations", new[] { "Campaign_CampaignId" });
            DropTable("dbo.VoluntaryActionVolunteers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.VoluntaryActions");
            DropTable("dbo.Invitations");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Donations");
            DropTable("dbo.FundraisingCampaigns");
        }
    }
}
