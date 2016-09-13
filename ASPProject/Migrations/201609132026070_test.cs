namespace ASPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PaymentMethod = c.Boolean(nullable: false),
                        CardType = c.String(nullable: false),
                        CardNumber = c.Long(nullable: false),
                        ExpirationDate = c.Int(nullable: false),
                        SecurityCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payments");
        }
    }
}
