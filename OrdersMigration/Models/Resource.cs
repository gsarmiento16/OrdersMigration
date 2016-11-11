using System;
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

        public virtual List<Inventory> Inventories { get; set; }


    }
}
