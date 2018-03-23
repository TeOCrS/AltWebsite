namespace AltWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentId = c.Int(nullable: false),
                        TouristId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Interval = c.Time(nullable: false, precision: 7),
                        Website = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payment", t => t.PaymentId, cascadeDelete: true)
                .ForeignKey("dbo.Tourist", t => t.TouristId, cascadeDelete: true)
                .Index(t => t.PaymentId)
                .Index(t => t.TouristId);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Double(nullable: false),
                        PricePerDay = c.Double(nullable: false),
                        CommisionFee = c.Double(nullable: false),
                        CleanupFee = c.Double(nullable: false),
                        NetAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TouristInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Country = c.String(),
                        PreferedLanguage = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tourist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TouristInfoId = c.Int(nullable: false),
                        Comments = c.String(),
                        Review = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TouristInfo", t => t.TouristInfoId, cascadeDelete: true)
                .Index(t => t.TouristInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tourist", "TouristInfoId", "dbo.TouristInfo");
            DropForeignKey("dbo.Booking", "TouristId", "dbo.Tourist");
            DropForeignKey("dbo.Booking", "PaymentId", "dbo.Payment");
            DropIndex("dbo.Tourist", new[] { "TouristInfoId" });
            DropIndex("dbo.Booking", new[] { "TouristId" });
            DropIndex("dbo.Booking", new[] { "PaymentId" });
            DropTable("dbo.Tourist");
            DropTable("dbo.TouristInfo");
            DropTable("dbo.Payment");
            DropTable("dbo.Booking");
        }
    }
}
