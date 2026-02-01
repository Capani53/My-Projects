using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HiFiAppClient.Areas.Admin.Models
{
    public class AddCategoryModel
    {        
        [JsonPropertyName("name")]
        [DisplayName("Kategori Adı")]       
        [Required(ErrorMessage = "Kategori adı gereklidir.")]
        [MinLength(5, ErrorMessage = "Bu alanın uzunluğu 5 karakterden kısa olamaz")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [MinLength(5, ErrorMessage = "Bu alanın uzunluğu 5 karakterden kısa olamaz")]
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
