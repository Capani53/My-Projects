using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace HiFiAppClient.Areas.Admin.Models
{
    public class EditCategoryModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "Kategori adı gereklidir.")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [JsonPropertyName("isHome")]
        [Display(Name = "Anasayfa")]
        public bool IsHome { get; set; }

        [JsonPropertyName("isActive")]
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }      
        
    }
}
