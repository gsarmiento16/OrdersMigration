using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
   public partial class Company
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string Ext_Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime Created { get; set; }
        public long UserCreated { get; set; }
        public DateTime Updated { get; set; }
        public long UserUpdated { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }

    }
}
