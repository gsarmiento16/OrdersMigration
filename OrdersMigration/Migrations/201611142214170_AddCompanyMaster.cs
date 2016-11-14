namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMaster : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vendors", "UserCreated", c => c.Long(nullable: false));
            AddColumn("dbo.Vendors", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vendors", "UserUpdated", c => c.Long(nullable: false));
            AddColumn("dbo.Companies", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "UserCreated", c => c.Long(nullable: false));
            AddColumn("dbo.Companies", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "UserUpdated", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "UserUpdated");
            DropColumn("dbo.Companies", "Updated");
            DropColumn("dbo.Companies", "UserCreated");
            DropColumn("dbo.Companies", "Created");
            DropColumn("dbo.Vendors", "UserUpdated");
            DropColumn("dbo.Vendors", "Updated");
            DropColumn("dbo.Vendors", "UserCreated");
            DropColumn("dbo.Vendors", "Created");
        }
    }
}
