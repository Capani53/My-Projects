using System;
using System.Text.Json.Serialization;

namespace HiFiAppClient.Models
{
    public class BrandViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }        

        [JsonPropertyName("PhotoUrl")]
        public string PhotoUrl { get; set; }
    }
}
