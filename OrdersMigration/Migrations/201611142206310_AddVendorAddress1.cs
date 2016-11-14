namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVendorAddress1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VendorAddresses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ext_Id = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        ZipCode = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        Email1 = c.String(),
                        Email2 = c.String(),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vendors", "VendorAddress_Id", c => c.Long());
            CreateIndex("dbo.Vendors", "VendorAddress_Id");
            AddForeignKey("dbo.Vendors", "VendorAddress_Id", "dbo.VendorAddresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendors", "VendorAddress_Id", "dbo.VendorAddresses");
            DropIndex("dbo.Vendors", new[] { "VendorAddress_Id" });
            DropColumn("dbo.Vendors", "VendorAddress_Id");
            DropTable("dbo.VendorAddresses");
        }
    }
}
