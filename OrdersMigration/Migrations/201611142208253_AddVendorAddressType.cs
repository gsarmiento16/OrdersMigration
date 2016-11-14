namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVendorAddressType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VendorAddresses", "AddressType_Id", c => c.Long());
            CreateIndex("dbo.VendorAddresses", "AddressType_Id");
            AddForeignKey("dbo.VendorAddresses", "AddressType_Id", "dbo.AddressTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendorAddresses", "AddressType_Id", "dbo.AddressTypes");
            DropIndex("dbo.VendorAddresses", new[] { "AddressType_Id" });
            DropColumn("dbo.VendorAddresses", "AddressType_Id");
        }
    }
}
