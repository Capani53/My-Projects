using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiFiApp.Shared.Dtos
{
    public class CategoryDto
    {
        public int id { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public DateTime ModifiedDate { get ; set ; }
        public bool IsActive { get ; set ; }
        public string Name { get ; set ; }
        public string Description { get; set; }
    }
}