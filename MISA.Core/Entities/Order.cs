using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Order:BaseEntity
    {
        public Guid OrderId { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int ShippingCost { get; set; }
        public string ReceviedAddress { get; set; }
        public string  TelephoneCustomer { get; set; }
        public string Email { get; set; }
        public string PaymentType { get; set; }
        public string Notes { get; set; }
        public Guid CustomerId { get; set; }

    }
}
