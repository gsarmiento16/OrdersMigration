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
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<ResourceClass> ResourceClasses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }



    }
}
