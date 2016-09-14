namespace ASPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedservicecreatecshtml : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "BillingFrequency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "BillingFrequency", c => c.Boolean(nullable: false));
        }
    }
}
