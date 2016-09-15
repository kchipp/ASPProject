namespace ASPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedpickupdayfromservicemodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "LastPickup");
            DropColumn("dbo.Services", "PickupDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "PickupDay", c => c.String());
            AddColumn("dbo.Services", "LastPickup", c => c.DateTime(nullable: false));
        }
    }
}
