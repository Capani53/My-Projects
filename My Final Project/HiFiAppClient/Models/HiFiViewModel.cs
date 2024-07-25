using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HiFiAppClient.Models
{
    public class HiFiViewModel
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("properties")]
        public string Properties { get; set; }

        [JsonPropertyName("summary")]
        public object Summary { get; set; }

        [JsonPropertyName("stock")]
        public int Stock { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("imageUrl")]
        public object ImageUrl { get; set; }

        [JsonPropertyName("categories")]
        public List<CategoryViewModel> Categories { get; set; }
    }
}