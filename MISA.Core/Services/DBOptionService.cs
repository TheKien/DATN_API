using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class DBOptionService : BaseService<DBOption>, IDBOptionService
    {
        #region declare

        IDBOptionRepository _dBOptionRepository;

        #endregion

        #region contructor
        public DBOptionService(IDBOptionRepository dBOptionRepository) : base(dBOptionRepository)
        {
            _dBOptionRepository = dBOptionRepository;
        }

        #endregion
    }
}
