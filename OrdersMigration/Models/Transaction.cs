using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
   public partial class Transaction
    {
        public long id { get; set; }
        public long DocumentNumber { get; set; }

        public long FromWarehoouse { get; set; }
        public long ToWarehoouse { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Created { get; set; }
        public long UserCreated { get; set; }


    }
}
