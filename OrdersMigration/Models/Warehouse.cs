using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
   public partial class Warehouse
    {
        public long Id { get; set; }
        public string Ext_id { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(255)]
        
        public string Notes { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public long UserCreated { get; set; }
        public DateTime Updated { get; set; }
        public long UserUpdated { get; set; }
        public virtual List<Inventory> Inventories { get; set; }
        
    }
}
