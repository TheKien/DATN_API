using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Setting:BaseEntity
    {
        public Guid SettingId { get; set; }
        public string SettingName { get; set; }
        public Guid SettingImageId { get; set; }
        public string SettingColor { get; set; }
        public string StartTime { get; set; }
    }
}
