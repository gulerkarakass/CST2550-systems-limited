namespace Event_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserIDNullable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Bookings", new[] { "UserID" });
            DropIndex("dbo.Bookings", new[] { "VenueID" });
            DropIndex("dbo.Reviews", new[] { "UserID" });
            DropIndex("dbo.Reviews", new[] { "VenueID" });
            DropIndex("dbo.Venue_Model", new[] { "UserID" });
            AlterColumn("dbo.Bookings", "UserID", c => c.Int());
            AlterColumn("dbo.Bookings", "VenueID", c => c.Int());
            AlterColumn("dbo.Reviews", "UserID", c => c.Int());
            AlterColumn("dbo.Reviews", "VenueID", c => c.Int());
            AlterColumn("dbo.Venue_Model", "UserID", c => c.Int());
            CreateIndex("dbo.Bookings", "UserID");
            CreateIndex("dbo.Bookings", "VenueID");
            CreateIndex("dbo.Reviews", "UserID");
            CreateIndex("dbo.Reviews", "VenueID");
            CreateIndex("dbo.Venue_Model", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Venue_Model", new[] { "UserID" });
            DropIndex("dbo.Reviews", new[] { "VenueID" });
            DropIndex("dbo.Reviews", new[] { "UserID" });
            DropIndex("dbo.Bookings", new[] { "VenueID" });
            DropIndex("dbo.Bookings", new[] { "UserID" });
            AlterColumn("dbo.Venue_Model", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "VenueID", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "VenueID", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Venue_Model", "UserID");
            CreateIndex("dbo.Reviews", "VenueID");
            CreateIndex("dbo.Reviews", "UserID");
            CreateIndex("dbo.Bookings", "VenueID");
            CreateIndex("dbo.Bookings", "UserID");
        }
    }
}
