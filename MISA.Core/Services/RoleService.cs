using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Service;
using MISA.Core.Entities;
using MISA.Core.Entities.Filter;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MISA.Core.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        #region declare

        IRoleRepostiory _roleRepostiory;

        #endregion

        #region contructor
        public RoleService(IRoleRepostiory roleService) : base(roleService)
        {
            _roleRepostiory = roleService;
        }

        #endregion
    }
}
