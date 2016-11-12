using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
   public partial class Tax
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public long UserCreated { get; set; }
        public DateTime Updated { get; set; }
        public long UserUpdated { get; set; }

        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }


    }
}
