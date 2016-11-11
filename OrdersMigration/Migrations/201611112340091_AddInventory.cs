namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Measurement_Id = c.Long(),
                        Resource_Id = c.Long(),
                        Warehouse_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Measurements", t => t.Measurement_Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Id)
                .Index(t => t.Measurement_Id)
                .Index(t => t.Resource_Id)
                .Index(t => t.Warehouse_Id);
            
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ext_Id = c.String(maxLength: 50),
                        Code = c.String(),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false, defaultValue: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.Inventories", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.Inventories", "Measurement_Id", "dbo.Measurements");
            DropIndex("dbo.Inventories", new[] { "Warehouse_Id" });
            DropIndex("dbo.Inventories", new[] { "Resource_Id" });
            DropIndex("dbo.Inventories", new[] { "Measurement_Id" });
            DropTable("dbo.Measurements");
            DropTable("dbo.Inventories");
        }
    }
}
