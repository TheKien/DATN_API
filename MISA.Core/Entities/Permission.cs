using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Permission:BaseEntity
    {
        public Guid PermissionId { get; set; }
        public string PermissionCode { get; set; }
        public string PermissionName { get; set; }
    }
}
