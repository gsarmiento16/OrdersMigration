namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSesion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Sesion", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Sesion");
        }
    }
}
