namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResourceTypeCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResourceTypes", "Code", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResourceTypes", "Code");
        }
    }
}
