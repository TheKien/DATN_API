using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class DBOption:BaseEntity
    {
        public Guid DBOptionId { get; set; }
        public string OptionId { get; set; }
        public string OptionValue { get; set; }
        public string Description { get; set; }
    }
}
