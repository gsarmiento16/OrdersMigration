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
        public string ext_id { get; set; }
        public string name { get; set; }
        public bool Active { get; set; }
        public virtual List<Resource> Resources { get; set; }
    }
}
