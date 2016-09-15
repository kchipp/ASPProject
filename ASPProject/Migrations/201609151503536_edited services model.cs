namespace ASPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedservicesmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "PickupDay", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "PickupDay", c => c.String(nullable: false));
        }
    }
}
