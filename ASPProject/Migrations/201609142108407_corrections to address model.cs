namespace ASPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctionstoaddressmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Address2", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Address2", c => c.String(nullable: false));
        }
    }
}
