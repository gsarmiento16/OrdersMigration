using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
    public partial class Measurement
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string Ext_Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual List<Inventory> Inventories { get; set; }


    }
}
