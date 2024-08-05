using HiFiApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Data.Concrete.EfCore.Configs
{
    internal class HiFiCategoryConfig : IEntityTypeConfiguration<HiFiCategory>
    {
        public void Configure(EntityTypeBuilder<HiFiCategory> builder)
        {
            builder.HasKey(hc => new { hc.HiFiId, hc.CategoryId });
            builder.ToTable("HiFiCategories");

            builder.HasData(
            new HiFiCategory { HiFiId = 1, CategoryId = 3 },
            new HiFiCategory { HiFiId = 1, CategoryId = 2 },

            new HiFiCategory { HiFiId = 2, CategoryId = 3 },
            new HiFiCategory { HiFiId = 2, CategoryId = 1 },

            new HiFiCategory { HiFiId = 3, CategoryId = 1 },
            new HiFiCategory { HiFiId = 3, CategoryId = 2 });      
        }
    }
}
