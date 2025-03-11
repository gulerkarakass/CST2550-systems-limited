namespace Event_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReservedDate = c.String(),
                        UserID = c.Int(nullable: false),
                        VenueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User_Model", t => t.UserID)
                .ForeignKey("dbo.Venue_Model", t => t.VenueID)
                .Index(t => t.UserID)
                .Index(t => t.VenueID);
            
            CreateTable(
                "dbo.User_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Postcode = c.String(),
                        DateOfBirth = c.String(nullable: false),
                        GenderID = c.Int(),
                        RoleID = c.Int(),
                        Pass = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gender_Model", t => t.GenderID)
                .ForeignKey("dbo.Role_Model", t => t.RoleID)
                .Index(t => t.GenderID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Gender_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UGender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        ReviewText = c.String(),
                        ReviewDate = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                        VenueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User_Model", t => t.UserID)
                .ForeignKey("dbo.Venue_Model", t => t.VenueID)
                .Index(t => t.UserID)
                .Index(t => t.VenueID);
            
            CreateTable(
                "dbo.Venue_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedOn = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                        TotalCapacity = c.Int(nullable: false),
                        Vacancy = c.Int(nullable: false),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category_Model", t => t.CategoryID)
                .ForeignKey("dbo.User_Model", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URole = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "VenueID", "dbo.Venue_Model");
            DropForeignKey("dbo.Bookings", "UserID", "dbo.User_Model");
            DropForeignKey("dbo.User_Model", "RoleID", "dbo.Role_Model");
            DropForeignKey("dbo.Reviews", "VenueID", "dbo.Venue_Model");
            DropForeignKey("dbo.Venue_Model", "UserID", "dbo.User_Model");
            DropForeignKey("dbo.Venue_Model", "CategoryID", "dbo.Category_Model");
            DropForeignKey("dbo.Reviews", "UserID", "dbo.User_Model");
            DropForeignKey("dbo.User_Model", "GenderID", "dbo.Gender_Model");
            DropIndex("dbo.Venue_Model", new[] { "CategoryID" });
            DropIndex("dbo.Venue_Model", new[] { "UserID" });
            DropIndex("dbo.Reviews", new[] { "VenueID" });
            DropIndex("dbo.Reviews", new[] { "UserID" });
            DropIndex("dbo.User_Model", new[] { "RoleID" });
            DropIndex("dbo.User_Model", new[] { "GenderID" });
            DropIndex("dbo.Bookings", new[] { "VenueID" });
            DropIndex("dbo.Bookings", new[] { "UserID" });
            DropTable("dbo.Role_Model");
            DropTable("dbo.Category_Model");
            DropTable("dbo.Venue_Model");
            DropTable("dbo.Reviews");
            DropTable("dbo.Gender_Model");
            DropTable("dbo.User_Model");
            DropTable("dbo.Bookings");
        }
    }
}
