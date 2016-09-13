namespace ASPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddbsets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Type = c.Boolean(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserPaymentJunctions",
                c => new
                    {
                        UserPaymentId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserPaymentId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        AddressId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        LastPickup = c.DateTime(nullable: false),
                        NextPickup = c.DateTime(nullable: false),
                        PickupDay = c.String(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BillingFrequency = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserAddressJunctions",
                c => new
                    {
                        UserAddressId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAddressId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.UserRouteJunctions",
                c => new
                    {
                        UserRouteId = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserRouteId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRouteJunctions", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.UserRouteJunctions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAddressJunctions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAddressJunctions", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Routes", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Services", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Routes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Routes", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUserPaymentJunctions", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.AspNetUserPaymentJunctions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Addresses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserRouteJunctions", new[] { "UserId" });
            DropIndex("dbo.UserRouteJunctions", new[] { "RouteId" });
            DropIndex("dbo.UserAddressJunctions", new[] { "AddressId" });
            DropIndex("dbo.UserAddressJunctions", new[] { "UserId" });
            DropIndex("dbo.Services", new[] { "UserId" });
            DropIndex("dbo.Routes", new[] { "ServiceId" });
            DropIndex("dbo.Routes", new[] { "AddressId" });
            DropIndex("dbo.Routes", new[] { "UserId" });
            DropIndex("dbo.AspNetUserPaymentJunctions", new[] { "PaymentId" });
            DropIndex("dbo.AspNetUserPaymentJunctions", new[] { "UserId" });
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropTable("dbo.UserRouteJunctions");
            DropTable("dbo.UserAddressJunctions");
            DropTable("dbo.Services");
            DropTable("dbo.Routes");
            DropTable("dbo.AspNetUserPaymentJunctions");
            DropTable("dbo.Addresses");
        }
    }
}
