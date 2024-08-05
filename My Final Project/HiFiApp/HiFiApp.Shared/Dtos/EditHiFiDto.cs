using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiFiApp.Shared.Dtos
{
    public class EditHiFiDto
    {
      public int Id { get; set; }
      public bool IsActive { get; set; }
      public string Name { get; set; }
      public string Properties { get; set; }
      public string Description { get; set; }
      public int Stock { get; set; }
      public decimal Price { get; set; }
      public string ImageUrl { get; set; }
      public bool IsHome { get; set; }
      public List<int> CategoryIds { get; set; } = [];
    }
}