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
    public class HiFiConfig : IEntityTypeConfiguration<HiFi>
    {
        public void Configure(EntityTypeBuilder<HiFi> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Properties).HasMaxLength(1000);
            builder.Property(x => x.Price).HasColumnType("real");
            builder.Property(x => x.Description).IsRequired(false);
            builder.ToTable("HiFis");
            builder.HasData(
            new HiFi
            {
                Id = 1,
                Name = "LG HT-1000EV",
                Properties = "DTS, Dolby Atmos, Bluetooth",
                Description = "HiFi Home Teathre",
                ImageUrl = "images/HiFis/lg.jpg",
                Stock = 200,
                Price = 30000,
                IsActive = true,
                IsHome = true,
                BrandId = 1
            },
            new HiFi
            {
                Id = 2,
                Name = "Samsung Q800C",
                Properties = "DTS, Dolby Atmos, Bluetooth",
                Description = "HiFi Soundbar",
                ImageUrl = "images/HiFis/samsung.jpg",
                Stock = 150,
                Price = 20000,
                IsActive = true,
                IsHome = true,
                BrandId = 2
            },
            new HiFi
            {
                Id = 3,
                Name = "JBL Quantum One",
                Properties = "DTS, Dolby Atmos",
                Description = "HiFi Headphone",
                ImageUrl = "images/HiFis/jbl.png",
                Stock = 100,
                Price = 10000,
                IsActive = true,
                IsHome = true,
                BrandId = 3           
            });
        }
    }
}
