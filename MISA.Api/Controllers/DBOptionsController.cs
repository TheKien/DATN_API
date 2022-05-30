using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MISA.Api.Controllers
{
    [ApiController]
    public class DBOptionsController : BaseEntitiesController<DBOption>
    {
        IDBOptionService _baseService;
        public DBOptionsController(IDBOptionService baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
