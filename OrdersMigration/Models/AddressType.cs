using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
    public partial class AddressType
    {
        public long Id { get; set; }
        public string Ext_Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<VendorAddress> VendorAddresses { get; set; }

    }
}
