using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HiFiApp.Shared.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public OrderDto Order { get; set; }
        public int HiFiId { get; set; }
        [JsonIgnore]
        public HiFiDto HiFi { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
