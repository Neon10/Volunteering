namespace Volunteering.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInvitationAndActionModels : DbMigration
    {
        public override void Up()
        {
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
                "dbo.VoluntaryActions",
                c => new
                    {
                        ActionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
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
            
            DropTable("dbo.Actions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        ActionId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ActionId);
            
            DropForeignKey("dbo.Invitations", "Volunteer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invitations", "Action_ActionId", "dbo.VoluntaryActions");
            DropForeignKey("dbo.VoluntaryActionVolunteers", "Volunteer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VoluntaryActionVolunteers", "VoluntaryAction_ActionId", "dbo.VoluntaryActions");
            DropForeignKey("dbo.VoluntaryActions", "CreatorNgo_Id", "dbo.AspNetUsers");
            DropIndex("dbo.VoluntaryActionVolunteers", new[] { "Volunteer_Id" });
            DropIndex("dbo.VoluntaryActionVolunteers", new[] { "VoluntaryAction_ActionId" });
            DropIndex("dbo.VoluntaryActions", new[] { "CreatorNgo_Id" });
            DropIndex("dbo.Invitations", new[] { "Volunteer_Id" });
            DropIndex("dbo.Invitations", new[] { "Action_ActionId" });
            DropTable("dbo.VoluntaryActionVolunteers");
            DropTable("dbo.VoluntaryActions");
            DropTable("dbo.Invitations");
        }
    }
}
