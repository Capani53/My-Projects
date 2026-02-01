using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HiFiApp.Shared.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int HiFiId { get; set; }
        public HiFiDto HiFi { get; set; }
        public int CartId { get; set; }
        [JsonIgnore]
        public CartDto Cart { get; set; }
        public int Quantity { get; set; }
    }
}
