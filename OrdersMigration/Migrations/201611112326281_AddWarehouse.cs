namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWarehouse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ext_id = c.String(),
                        Code = c.String(maxLength: 20),
                        Notes = c.String(maxLength: 255, nullable: false),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Warehouses");
        }
    }
}
