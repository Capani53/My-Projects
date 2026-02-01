using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HiFiAppClient.Models
{
    public class CategoryViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("CountOfHiFi")]
        public int CountOfHiFi { get; set; }

        [JsonPropertyName("ImageUrl")]
        public string ImageUrl { get; set; }
    }
}