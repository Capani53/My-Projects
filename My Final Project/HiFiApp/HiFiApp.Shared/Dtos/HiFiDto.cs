using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiFiApp.Shared.Dtos
{
    public class HiFiDto
    {
        public int id { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public DateTime ModifiedDate { get ; set ; }
        public bool IsActive { get ; set ; }
        //ICommon
        public string Name { get ; set ; }
        //HiFi
        public string Properties { get; set; }
        public string Description { get; set ; }

        public int Stock { get; set; }
        public  decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}