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
    public class DBOptionRepository : BaseRepository<DBOption>, IDBOptionRepository
    {
        public DBOptionRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
