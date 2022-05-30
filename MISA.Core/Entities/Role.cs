using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Role : BaseEntity
    {
        public Guid RoleId { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
    }
}
