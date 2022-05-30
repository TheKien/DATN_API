﻿using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        #region declare

        IOrderRepository _orderRepository;

        #endregion

        #region contructor
        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }

        #endregion
    }
}
