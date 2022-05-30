using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public User Login(string userName, string password)
        {
#if DEBUG
            User user = new User();
            user.UserName = userName;
            user.Password = password;
            user.lstPermission = "product_view, product_edit, product_delete, product_add";
            return user;
#endif
            DynamicParameters parameters = new();
            var storeName = $"Proc_UserLogin";
            parameters.Add("$UserName", userName);
            parameters.Add("$Password", password);
            // Thực thi lấy dữ liệu trong db:
            User result = _dbConnection.Query<User>(storeName, param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            string lstPermission = parameters.Get<string>("$LstPermission");
            result.lstPermission = lstPermission;
            return result;
        }
    }
}
