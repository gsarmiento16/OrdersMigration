using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
  public partial class Invoice
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public DateTime Created { get; set; }
        public long UserCreated { get; set; }
        public DateTime Updated { get; set; }
        public long UserUpdated { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    }
}
