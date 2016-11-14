namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompany1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ext_Id = c.String(maxLength: 50),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Identification = c.String(),
                        Company_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            AddColumn("dbo.Customers", "Company_Id", c => c.Long());
            AddColumn("dbo.Quotations", "Company_Id", c => c.Long());
            AddColumn("dbo.Invoices", "Company_Id", c => c.Long());
            AddColumn("dbo.Transactions", "Company_Id", c => c.Long());
            AddColumn("dbo.Inventories", "Company_Id", c => c.Long());
            AddColumn("dbo.Resources", "Company_Id", c => c.Long());
            AddColumn("dbo.Orders", "Company_Id", c => c.Long());
            AddColumn("dbo.Users", "Company_Id", c => c.Long());
            CreateIndex("dbo.Customers", "Company_Id");
            CreateIndex("dbo.Quotations", "Company_Id");
            CreateIndex("dbo.Inventories", "Company_Id");
            CreateIndex("dbo.Invoices", "Company_Id");
            CreateIndex("dbo.Orders", "Company_Id");
            CreateIndex("dbo.Resources", "Company_Id");
            CreateIndex("dbo.Transactions", "Company_Id");
            CreateIndex("dbo.Users", "Company_Id");
            AddForeignKey("dbo.Customers", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Inventories", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Invoices", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Orders", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Quotations", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Resources", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Transactions", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Users", "Company_Id", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendors", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Users", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Transactions", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Resources", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Quotations", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Orders", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Inventories", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Customers", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Vendors", new[] { "Company_Id" });
            DropIndex("dbo.Users", new[] { "Company_Id" });
            DropIndex("dbo.Transactions", new[] { "Company_Id" });
            DropIndex("dbo.Resources", new[] { "Company_Id" });
            DropIndex("dbo.Orders", new[] { "Company_Id" });
            DropIndex("dbo.Invoices", new[] { "Company_Id" });
            DropIndex("dbo.Inventories", new[] { "Company_Id" });
            DropIndex("dbo.Quotations", new[] { "Company_Id" });
            DropIndex("dbo.Customers", new[] { "Company_Id" });
            DropColumn("dbo.Users", "Company_Id");
            DropColumn("dbo.Orders", "Company_Id");
            DropColumn("dbo.Resources", "Company_Id");
            DropColumn("dbo.Inventories", "Company_Id");
            DropColumn("dbo.Transactions", "Company_Id");
            DropColumn("dbo.Invoices", "Company_Id");
            DropColumn("dbo.Quotations", "Company_Id");
            DropColumn("dbo.Customers", "Company_Id");
            DropTable("dbo.Vendors");
            DropTable("dbo.Companies");
        }
    }
}
