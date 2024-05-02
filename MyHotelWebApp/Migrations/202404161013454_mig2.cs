namespace MyHotelWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.String(nullable: false, maxLength: 128),
                        AdminName = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logins");
            DropTable("dbo.Admins");
        }
    }
}
