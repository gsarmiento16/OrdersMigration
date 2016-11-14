using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersMigration.Util
{
    public class Result<T>
    {
        public int type { get; set; }
        public string message { get; set; }
        public ICollection<T> Collection { get; set; } 
        public long Entity { get; set; }
    }

}
