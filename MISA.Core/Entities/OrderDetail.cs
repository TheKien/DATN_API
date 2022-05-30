using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class OrderDetail:BaseEntity
    {
        public Guid OrderDetailId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
