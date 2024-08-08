using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HiFiAppClient.Areas.Admin.Models
{
    public class AddHiFiModel
    {

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isHome")]
        public bool IsHome { get; set; }

        [JsonPropertyName("name")]
        [DisplayName("HiFi Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [MinLength(5,ErrorMessage ="Bu alan 5 uzunluğu karakterden kısa olamaz")]
        public string Name { get; set; }

        [JsonPropertyName("properties")]
        [DisplayName("Özellikler")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [MinLength(5, ErrorMessage = "Bu alan 5 uzunluğu karakterden kısa olamaz")]
        public string Properties { get; set; }

        [JsonPropertyName("description")]
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [MinLength(5, ErrorMessage = "Bu alan 5 uzunluğu karakterden kısa olamaz")]
        public string Description { get; set; }

        [JsonPropertyName("stock")]
        [DisplayName("Stok")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(minimum:0, maximum:100, ErrorMessage = "Bu alana 0-1000 aralığı dışında bir değer girilemez")]
        public int? Stock { get; set; }

        [JsonPropertyName("price")]
        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(minimum: 5000, maximum: 200000, ErrorMessage = "Bu alana 0-1000 aralığı dışında bir değer girilemez")]
        public decimal? Price { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("categoryIds")]
        public List<int> CategoryIds { get; set; }

        [JsonPropertyName("brandId")]
        public int BrandId { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        public List<SelectListItem> BrandList { get; set; }
    }
}
