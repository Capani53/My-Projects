using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Entity.Abstract;

namespace HiFiApp.Entity.Concrete
{
    public class Category : IBaseEntity, ICommonEntity
    {
        public int Id { get ; set ; }
        public DateTime CreatedDate { get ; set ; }=DateTime.Now;
        public DateTime ModifiedDate { get ; set ; }=DateTime.Now;
        public bool IsActive { get ; set ; }
        public string Name { get ; set ; }
        public string Description { get; set; }
        public List<HiFiCategory> HiFiCategories { get; set; }
    }
}