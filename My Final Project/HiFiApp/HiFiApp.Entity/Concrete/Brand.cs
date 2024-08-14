using HiFiApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Entity.Concrete
{
    public class Brand : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public DateTime ModifiedDate { get; set; }=DateTime.Now;
        public bool IsActive { get; set; }
        public string Name { get; set; }        
        public string PhotoUrl { get; set; }
        public List<HiFi> HiFis { get; set; }
    }
}
