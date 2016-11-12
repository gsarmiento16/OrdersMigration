using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
   public partial class DocumentType
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string ext_id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<NextNumber> NextNumbers { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
