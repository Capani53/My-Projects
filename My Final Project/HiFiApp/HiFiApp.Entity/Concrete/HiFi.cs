using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Entity.Abstract;

namespace HiFiApp.Entity.Concrete
{
    public class HiFi:IBaseEntity,ICommonEntity
    {
        //IBase
        public int Id { get ; set ; }
        public DateTime CreatedDate { get ; set ; }=DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get ; set ; }
        //ICommon
        public string Name { get ; set ; }
        //HiFi
        public string Properties { get; set; }
        public string Description { get; set ; }

        public int Stock { get; set; }
        public  decimal Price { get; set; }
        public string ImageUrl { get; set; }
        //Navigation Properties
        public List<HiFiCategory> HiFiCategories { get; set; }
    }
}