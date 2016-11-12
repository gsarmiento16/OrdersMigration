using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
  public partial  class IdentificationType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vendor> Vendors { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
    }
}
