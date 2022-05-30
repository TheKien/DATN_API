using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.Api.Controllers
{
    [ApiController]
    public class RolesController : BaseEntitiesController<Role>
    {
        IRoleService _baseService;
        public RolesController(IRoleService baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
