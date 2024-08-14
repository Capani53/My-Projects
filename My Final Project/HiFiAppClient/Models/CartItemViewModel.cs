using System;
using System.Text.Json.Serialization;

namespace HiFiAppClient.Models
{
    public class CartItemViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("HiFiId")]
        public int HiFiId { get; set; }

        [JsonPropertyName("HiFi")]
        public HiFiViewModel HiFi { get; set; }

        [JsonPropertyName("CartId")]
        public int CartId { get; set; }

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }
    }
}
