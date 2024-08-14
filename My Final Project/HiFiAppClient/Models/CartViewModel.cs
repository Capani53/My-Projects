using NuGet.Common;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HiFiAppClient.Models
{
    public class CartViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("UserId")]
        public string UserId { get; set; }

        [JsonPropertyName("CartItems")]
        public List<CartItemViewModel> CartItems { get; set; }
    }
}
