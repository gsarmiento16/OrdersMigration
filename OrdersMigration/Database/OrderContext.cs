using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersMigration.Models;

namespace OrdersMigration.Database
{
    public class OrderContext : DbContext
    {
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyMaster> CompanieMasters { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<NextNumber> NetNumbers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationDetail> QuotationDetails { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<ResourceClass> ResourceClasses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorAddress> VendorAddresses { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }



    }
}
