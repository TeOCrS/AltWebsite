namespace AltWebsite.Migrations
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
                        Id = c.Int(nullable: false, identity: true),
                        TouristId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Interval = c.Time(nullable: false, precision: 7),
                        Website = c.Int(nullable: false),
                        Commision = c.Double(nullable: false),
                        Payment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.Payment_Id)
                .ForeignKey("dbo.Tourists", t => t.TouristId, cascadeDelete: true)
                .Index(t => t.TouristId)
                .Index(t => t.Payment_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        PricePerDay = c.Double(nullable: false),
                        ComisionFee = c.Double(nullable: false),
                        CleanupFee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TouristInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TouristId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Country = c.String(),
                        PreferedLanguage = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tourists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comments = c.String(),
                        Review = c.String(),
                        TouristInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TouristInfoes", t => t.TouristInfo_Id)
                .Index(t => t.TouristInfo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tourists", "TouristInfo_Id", "dbo.TouristInfoes");
            DropForeignKey("dbo.Bookings", "TouristId", "dbo.Tourists");
            DropForeignKey("dbo.Bookings", "Payment_Id", "dbo.Payments");
            DropIndex("dbo.Tourists", new[] { "TouristInfo_Id" });
            DropIndex("dbo.Bookings", new[] { "Payment_Id" });
            DropIndex("dbo.Bookings", new[] { "TouristId" });
            DropTable("dbo.Tourists");
            DropTable("dbo.TouristInfoes");
            DropTable("dbo.Payments");
            DropTable("dbo.Bookings");
        }
    }
}
