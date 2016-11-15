using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Models
{
    public partial class User
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string Ext_Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Sesion { get; set; }
        public string Password { get; set; }
        public bool ChangePassword { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public long UserCreated { get; set; }
        public DateTime Updated { get; set; }
        public long UserUpdated { get; set; }
    }
}
