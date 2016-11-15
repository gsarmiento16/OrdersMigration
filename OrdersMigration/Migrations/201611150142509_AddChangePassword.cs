namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChangePassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ChangePassword", c => c.Boolean(nullable: false,defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ChangePassword");
        }
    }
}
