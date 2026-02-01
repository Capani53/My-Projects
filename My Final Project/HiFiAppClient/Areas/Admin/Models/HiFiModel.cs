using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HiFiAppClient.Areas.Admin.Models
{
    public class HiFiModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("IsHome")]
        public bool IsHome { get; set; }

        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Properties")]
        public string Properties { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Stock")]
        public int Stock { get; set; }

        [JsonPropertyName("Price")]
        public decimal Price { get; set; }        

        [JsonPropertyName("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("Categories")]
        public List<CategoryModel> Categories { get; set; }

        [JsonPropertyName("Brand")]
        public BrandModel Brand { get; set; }
    }
}
