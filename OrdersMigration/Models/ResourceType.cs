using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
    public partial class ResourceType
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string Ext_id { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
