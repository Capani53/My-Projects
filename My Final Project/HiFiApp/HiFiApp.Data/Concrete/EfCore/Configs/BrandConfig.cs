using HiFiApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFiApp.Data.Concrete.EfCore.Configs
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
            new Brand
            {
                Id = 1,
                Name = "LG",
                PhotoUrl = "LG-logo.jpg"
            },
            new Brand
            {
                Id = 2,
                Name = "Samsung",
                PhotoUrl = "Samsung-logo.jpg"
            },
            new Brand
            {
                Id = 3,
                Name = "JBL",
                PhotoUrl = "JBL-logo.jpg"
            });
        }
    }
}
