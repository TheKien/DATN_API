using MISA.Core.Interfaces.Repository;
using MISA.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Common
{
    public class CommonFunction
    {
        public CommonFunction()
        {

        }

        public Boolean checkPermissionUser(string lstPermission, string permissionCode)
        {
            if (lstPermission.Contains(permissionCode))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
