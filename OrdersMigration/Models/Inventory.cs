using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
   public partial class Inventory
    {
        public long Id { get; set; }
        public decimal Quantity { get; set; }
    }
}
