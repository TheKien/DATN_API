using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string lstPermission { get; set; }
    }
}
