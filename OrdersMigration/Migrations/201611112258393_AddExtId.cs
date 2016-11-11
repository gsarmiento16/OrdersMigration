namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExtId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResourceClasses", "ext_id", c => c.String(maxLength: 50));
            AddColumn("dbo.ResourceTypes", "ext_id", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResourceTypes", "ext_id");
            DropColumn("dbo.ResourceClasses", "ext_id");
        }
    }
}
