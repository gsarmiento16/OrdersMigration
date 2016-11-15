namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRole1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ext_Id = c.String(),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserRole_Id", c => c.Long());
            CreateIndex("dbo.Users", "UserRole_Id");
            AddForeignKey("dbo.Users", "UserRole_Id", "dbo.UserRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRole_Id", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRole_Id" });
            DropColumn("dbo.Users", "UserRole_Id");
            DropTable("dbo.UserRoles");
        }
    }
}
