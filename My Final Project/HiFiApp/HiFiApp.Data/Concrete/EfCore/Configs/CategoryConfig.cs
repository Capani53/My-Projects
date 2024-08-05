using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiFiApp.Data.Concrete.EfCore.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
            {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).IsRequired(false).HasMaxLength(500);
            builder.ToTable("Categories");
            
            builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Home Theathre",
                Description = "HiFi Home Teathre",
                IsHome = true,
            },
            new Category
            {
                Id = 2,
                Name = "Soundbars",
                Description = "HiFi soundbar",
                IsHome = true,
            },
            new Category
            {
                Id = 3,
                Name = "Headphones",
                Description = "HiFi Headphone",
                IsHome = true,
                
            });
        }
    }
}