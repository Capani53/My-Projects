using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Shared.Dtos
{
    public class AddToCartDto
    {
        public string UserId { get; set; }
        public int HiFiId { get; set; }
        public int Quantity { get; set; }
    }
}
