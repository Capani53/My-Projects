using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Entity.Concrete
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }= DateTime.Now;
        public string UserId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
