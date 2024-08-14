using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiFiApp.Shared.Dtos
{
    public class AddCategoryDto
    {
        public string Name { get; set; }        
        public bool IsHome { get; set; }
    }
}