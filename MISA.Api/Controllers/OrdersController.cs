using EmailService;
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
    public class OrdersController : BaseEntitiesController<Order>
    {
        IOrderService _baseService;
        public OrdersController(IOrderService baseService, IEmailSender emailSender) : base(baseService)
        {
            _baseService = baseService;
        }

    }
}
