namespace Volunteering.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RebuildAmel : DbMigration
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
                        OwnerNgoId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.CampaignId)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerNgoId, cascadeDelete: true)
                .Index(t => t.OwnerNgoId);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        VolunteerId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        CampaignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DonationId)
                .ForeignKey("dbo.FundraisingCampaigns", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.VolunteerId, cascadeDelete: true)
                .Index(t => t.VolunteerId)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
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
                "dbo.Discussions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Content = c.String(nullable: false, unicode: false),
                        CreationDate = c.DateTime(nullable: false, precision: 0),
                        IsViewed = c.Boolean(nullable: false),
                        SenderId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RecipientId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ApplicationUser_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RecipientId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId, cascadeDelete: true)
                .Index(t => t.SenderId)
                .Index(t => t.RecipientId)
                .Index(t => t.ApplicationUser_Id);
            
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        CreatorNgoId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ActionId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorNgoId, cascadeDelete: true)
                .Index(t => t.CreatorNgoId);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, unicode: false),
                        IsNew = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        SenderId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        DiscussionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discussions", t => t.DiscussionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId, cascadeDelete: true)
                .Index(t => t.SenderId)
                .Index(t => t.DiscussionId);
            
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        InvitationId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Action_ActionId = c.Int(),
                        Volunteer_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.InvitationId)
                .ForeignKey("dbo.VoluntaryActions", t => t.Action_ActionId)
                .ForeignKey("dbo.AspNetUsers", t => t.Volunteer_Id)
                .Index(t => t.Action_ActionId)
                .Index(t => t.Volunteer_Id);
            
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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FundraisingCampaigns", "OwnerNgoId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invitations", "Volunteer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invitations", "Action_ActionId", "dbo.VoluntaryActions");
            DropForeignKey("dbo.Donations", "VolunteerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Discussions", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Replies", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Replies", "DiscussionId", "dbo.Discussions");
            DropForeignKey("dbo.Discussions", "RecipientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VoluntaryActionVolunteers", "Volunteer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VoluntaryActionVolunteers", "VoluntaryAction_ActionId", "dbo.VoluntaryActions");
            DropForeignKey("dbo.VoluntaryActions", "CreatorNgoId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Discussions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Donations", "CampaignId", "dbo.FundraisingCampaigns");
            DropIndex("dbo.VoluntaryActionVolunteers", new[] { "Volunteer_Id" });
            DropIndex("dbo.VoluntaryActionVolunteers", new[] { "VoluntaryAction_ActionId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Invitations", new[] { "Volunteer_Id" });
            DropIndex("dbo.Invitations", new[] { "Action_ActionId" });
            DropIndex("dbo.Replies", new[] { "DiscussionId" });
            DropIndex("dbo.Replies", new[] { "SenderId" });
            DropIndex("dbo.VoluntaryActions", new[] { "CreatorNgoId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Discussions", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Discussions", new[] { "RecipientId" });
            DropIndex("dbo.Discussions", new[] { "SenderId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Donations", new[] { "CampaignId" });
            DropIndex("dbo.Donations", new[] { "VolunteerId" });
            DropIndex("dbo.FundraisingCampaigns", new[] { "OwnerNgoId" });
            DropTable("dbo.VoluntaryActionVolunteers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Invitations");
            DropTable("dbo.Replies");
            DropTable("dbo.VoluntaryActions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Discussions");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Donations");
            DropTable("dbo.FundraisingCampaigns");
        }
    }
}
