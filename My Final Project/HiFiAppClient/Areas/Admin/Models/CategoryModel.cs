using NuGet.Common;
using System;
using System.Text.Json.Serialization;

namespace HiFiAppClient.Areas.Admin.Models
{
    public class CategoryModel
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

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("IsHome")]
        public bool IsHome { get; set; }

        [JsonPropertyName("CountOfHiFi")]
        public int CountOfHiFi { get; set; }
    }
}
