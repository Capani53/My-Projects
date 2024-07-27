using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName ("HiFi Adý")]
        public string Name { get; set; }

        [JsonPropertyName("properties")]
        [DisplayName("Özellikler")]
        public string Properties { get; set; }
       
        [JsonPropertyName("description")]
        [DisplayName("Açýklama")]
        public string Description { get; set; }

        [JsonPropertyName("stock")]
        [DisplayName("Stok")]
        public int Stock { get; set; }
        
        [JsonPropertyName("price")]
        [DisplayName("Fiyat")]
        public decimal Price { get; set; }
       
        [JsonPropertyName("imageUrl")]
        [DisplayName("Resim")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("categories")]
        [DisplayName("Kategoriler")]
        public List<CategoryViewModel> Categories { get; set; }
    }
}