namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResourceClass2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResourceClasses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 20),
                        Name = c.String(maxLength: 50),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Resources", "ResourceClass_Id", c => c.Long());
            CreateIndex("dbo.Resources", "ResourceClass_Id");
            AddForeignKey("dbo.Resources", "ResourceClass_Id", "dbo.ResourceClasses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "ResourceClass_Id", "dbo.ResourceClasses");
            DropIndex("dbo.Resources", new[] { "ResourceClass_Id" });
            DropColumn("dbo.Resources", "ResourceClass_Id");
            DropTable("dbo.ResourceClasses");
        }
    }
}
