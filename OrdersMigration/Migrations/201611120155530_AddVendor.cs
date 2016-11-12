namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVendor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Identification", c => c.String());
            AddColumn("dbo.Customers", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Number");
            DropColumn("dbo.Customers", "Identification");
        }
    }
}
