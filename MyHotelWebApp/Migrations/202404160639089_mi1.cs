namespace MyHotelWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mi1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false),
                        CustomerId = c.String(maxLength: 128),
                        RoomId = c.Int(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        TotalAmount = c.String(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        CustomerName = c.String(),
                        CustomerDob = c.DateTime(nullable: false),
                        CustomerEmail = c.String(),
                        CustomerPhone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        AmountPaid = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        HotelId = c.String(maxLength: 128),
                        Roomtype = c.String(),
                        RoomPriced = c.Double(nullable: false),
                        RoomAvailability = c.String(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Hotels", t => t.HotelId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelID = c.String(nullable: false, maxLength: 128),
                        HotelName = c.String(),
                        HotelAddress = c.String(),
                        HotelPhone = c.String(),
                    })
                .PrimaryKey(t => t.HotelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Payments", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            DropIndex("dbo.Payments", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropTable("dbo.Hotels");
            DropTable("dbo.Rooms");
            DropTable("dbo.Payments");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
