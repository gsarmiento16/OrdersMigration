using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
    public partial class CompanyMaster
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string Ext_Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public DateTime Created { get; set; }
        public long UserCreated { get; set; }
        public DateTime Updated { get; set; }
        public long UserUpdated { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
