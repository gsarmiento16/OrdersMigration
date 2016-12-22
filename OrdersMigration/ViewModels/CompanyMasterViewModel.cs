using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.ViewModels
{
    public partial class CompanyMasterViewModel
    {
        public string Ext_Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public DateTime Created { get; set; }
        public string UserCreated { get; set; }
        public DateTime Updated { get; set; }
        public string UserUpdated { get; set; }
    }
}
