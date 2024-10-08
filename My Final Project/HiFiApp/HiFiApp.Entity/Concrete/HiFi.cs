using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Entity.Abstract;

namespace HiFiApp.Entity.Concrete
{
    public class HiFi : IBaseEntity, ICommonEntity
    {           
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public DateTime ModifiedDate { get; set; }=DateTime.Now;
        public bool IsActive { get; set; }        
        public string Name { get; set; }        
        public string Properties { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }        
        public string ImageUrl { get; set; }
        public bool IsHome { get; set; }        
        public List<HiFiCategory> HiFiCategories { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}