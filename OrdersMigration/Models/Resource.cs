﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
    public partial class Resource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Serial { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public long UserCreated { get; set; }
        public DateTime Updated { get; set; }
        public long UserUpdated { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<QuotationDetail> QuotationsDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }


    }
}
