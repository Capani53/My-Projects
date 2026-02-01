using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiFiApp.Entity.Concrete
{
    public class HiFiCategory
    {
        public int HiFiId { get; set; }
        public HiFi HiFi { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}