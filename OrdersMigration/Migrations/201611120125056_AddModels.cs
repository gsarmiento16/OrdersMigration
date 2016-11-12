namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ext_Id = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerAddresses",
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
                        AddressType_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressTypes", t => t.AddressType_Id)
                .Index(t => t.AddressType_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ext_Id = c.String(maxLength: 50),
                        Name = c.String(),
                        Notes = c.String(),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                        CustomerAddress_Id = c.Long(),
                        CustomerType_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerAddresses", t => t.CustomerAddress_Id)
                .ForeignKey("dbo.CustomerTypes", t => t.CustomerType_Id)
                .Index(t => t.CustomerAddress_Id)
                .Index(t => t.CustomerType_Id);
            
            CreateTable(
                "dbo.Quotations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                        Customer_Id = c.Long(),
                        NextNumber_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.NextNumbers", t => t.NextNumber_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.NextNumber_Id);
            
            CreateTable(
                "dbo.QuotationDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Line = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                        Quotation_Id = c.Long(),
                        Measurement_Id = c.Long(),
                        Resource_Id = c.Long(),
                        Tax_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quotations", t => t.Quotation_Id)
                .ForeignKey("dbo.Measurements", t => t.Measurement_Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .ForeignKey("dbo.Taxes", t => t.Tax_Id)
                .Index(t => t.Quotation_Id)
                .Index(t => t.Measurement_Id)
                .Index(t => t.Resource_Id)
                .Index(t => t.Tax_Id);
            
            CreateTable(
                "dbo.CustomerTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ext_Id = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ext_id = c.String(maxLength: 50),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                        DocumentType_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentType_Id)
                .Index(t => t.DocumentType_Id);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Line = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                        Invoice_Id = c.Long(),
                        Measurement_Id = c.Long(),
                        Resource_Id = c.Long(),
                        Tax_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .ForeignKey("dbo.Measurements", t => t.Measurement_Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .ForeignKey("dbo.Taxes", t => t.Tax_Id)
                .Index(t => t.Invoice_Id)
                .Index(t => t.Measurement_Id)
                .Index(t => t.Resource_Id)
                .Index(t => t.Tax_Id);
            
            CreateTable(
                "dbo.NextNumbers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        Format = c.String(),
                        Notes = c.String(),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                        DocumentType_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentType_Id)
                .Index(t => t.DocumentType_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        DocumentNumber = c.Long(nullable: false),
                        FromWarehoouse = c.Long(nullable: false),
                        ToWarehoouse = c.Long(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        DocumentType_Id = c.Long(),
                        Resource_Id = c.Long(),
                        TransactionType_Id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentType_Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionType_Id)
                .Index(t => t.DocumentType_Id)
                .Index(t => t.Resource_Id)
                .Index(t => t.TransactionType_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Line = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                        Measurement_Id = c.Long(),
                        Resource_Id = c.Long(),
                        Order_Id = c.Long(),
                        Tax_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Measurements", t => t.Measurement_Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Taxes", t => t.Tax_Id)
                .Index(t => t.Measurement_Id)
                .Index(t => t.Resource_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Tax_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        Quotation_Id = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ext_Id = c.String(maxLength: 50),
                        Name = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Resources", "SKU", c => c.String());
            AddColumn("dbo.Resources", "Serial", c => c.String());
            AddColumn("dbo.Resources", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Resources", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Resources", "UserCreated", c => c.Long(nullable: false));
            AddColumn("dbo.Resources", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Resources", "UserUpdated", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransactionType_Id", "dbo.TransactionTypes");
            DropForeignKey("dbo.QuotationDetails", "Tax_Id", "dbo.Taxes");
            DropForeignKey("dbo.OrderDetails", "Tax_Id", "dbo.Taxes");
            DropForeignKey("dbo.InvoiceDetails", "Tax_Id", "dbo.Taxes");
            DropForeignKey("dbo.OrderDetails", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Transactions", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.QuotationDetails", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.OrderDetails", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.InvoiceDetails", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.QuotationDetails", "Measurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.OrderDetails", "Measurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.InvoiceDetails", "Measurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.Transactions", "DocumentType_Id", "dbo.DocumentTypes");
            DropForeignKey("dbo.NextNumbers", "DocumentType_Id", "dbo.DocumentTypes");
            DropForeignKey("dbo.Quotations", "NextNumber_Id", "dbo.NextNumbers");
            DropForeignKey("dbo.Invoices", "DocumentType_Id", "dbo.DocumentTypes");
            DropForeignKey("dbo.InvoiceDetails", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.Customers", "CustomerType_Id", "dbo.CustomerTypes");
            DropForeignKey("dbo.CustomerAddresses", "AddressType_Id", "dbo.AddressTypes");
            DropForeignKey("dbo.Customers", "CustomerAddress_Id", "dbo.CustomerAddresses");
            DropForeignKey("dbo.Quotations", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.QuotationDetails", "Quotation_Id", "dbo.Quotations");
            DropIndex("dbo.OrderDetails", new[] { "Tax_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Order_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Resource_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Measurement_Id" });
            DropIndex("dbo.Transactions", new[] { "TransactionType_Id" });
            DropIndex("dbo.Transactions", new[] { "Resource_Id" });
            DropIndex("dbo.Transactions", new[] { "DocumentType_Id" });
            DropIndex("dbo.NextNumbers", new[] { "DocumentType_Id" });
            DropIndex("dbo.InvoiceDetails", new[] { "Tax_Id" });
            DropIndex("dbo.InvoiceDetails", new[] { "Resource_Id" });
            DropIndex("dbo.InvoiceDetails", new[] { "Measurement_Id" });
            DropIndex("dbo.InvoiceDetails", new[] { "Invoice_Id" });
            DropIndex("dbo.Invoices", new[] { "DocumentType_Id" });
            DropIndex("dbo.QuotationDetails", new[] { "Tax_Id" });
            DropIndex("dbo.QuotationDetails", new[] { "Resource_Id" });
            DropIndex("dbo.QuotationDetails", new[] { "Measurement_Id" });
            DropIndex("dbo.QuotationDetails", new[] { "Quotation_Id" });
            DropIndex("dbo.Quotations", new[] { "NextNumber_Id" });
            DropIndex("dbo.Quotations", new[] { "Customer_Id" });
            DropIndex("dbo.Customers", new[] { "CustomerType_Id" });
            DropIndex("dbo.Customers", new[] { "CustomerAddress_Id" });
            DropIndex("dbo.CustomerAddresses", new[] { "AddressType_Id" });
            DropColumn("dbo.Resources", "UserUpdated");
            DropColumn("dbo.Resources", "Updated");
            DropColumn("dbo.Resources", "UserCreated");
            DropColumn("dbo.Resources", "Created");
            DropColumn("dbo.Resources", "Active");
            DropColumn("dbo.Resources", "Serial");
            DropColumn("dbo.Resources", "SKU");
            DropTable("dbo.Users");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Taxes");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Transactions");
            DropTable("dbo.NextNumbers");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Invoices");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.CustomerTypes");
            DropTable("dbo.QuotationDetails");
            DropTable("dbo.Quotations");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerAddresses");
            DropTable("dbo.AddressTypes");
        }
    }
}
