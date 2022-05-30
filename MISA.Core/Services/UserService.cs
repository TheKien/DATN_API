using Microsoft.AspNetCore.Http;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        #region declare

        IUserRepository _userRepository;

        #endregion

        #region contructor
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public ServiceResult Login(string userName, string password)
        {
            var res = _userRepository.Login(userName, password);
            if (res != null)
            {
                _serviceResult.Data = res;
                _serviceResult.MISACode = Enums.MISAEnum.MISACode.Success;
            }
            else
            {
                _serviceResult.Message = Properties.Resources.Msg_IsNotValid;
                _serviceResult.MISACode = Enums.MISAEnum.MISACode.NotValid;
            }
            return _serviceResult;
        }

        #endregion
    }
}
