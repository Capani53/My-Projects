using System.Collections.Generic;

namespace HiFiAppClient.Models
{
    public class HomePageModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<HiFiViewModel> HiFis { get; set; }
    }
}
