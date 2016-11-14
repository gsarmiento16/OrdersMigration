namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResources : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ResourceType_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResourceTypes", t => t.ResourceType_Id)
                .Index(t => t.ResourceType_Id);
            
            CreateTable(
                "dbo.ResourceTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        Active = c.Boolean(nullable: false, defaultValue: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "ResourceType_Id", "dbo.ResourceTypes");
            DropIndex("dbo.Resources", new[] { "ResourceType_Id" });
            DropTable("dbo.ResourceTypes");
            DropTable("dbo.Resources");
        }
    }
}
