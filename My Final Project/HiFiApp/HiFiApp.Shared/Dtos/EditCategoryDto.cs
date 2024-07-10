using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiFiApp.Shared.Dtos
{
    public class EditCategoryDto
    {
        public int id { get ; set ; }
        public string Name { get ; set ; }
        public string Description { get; set; }
        public bool IsActive { get ; set ; }
    }
}