using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HiFiApp.Data
{
    public class OldHiFiAppDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<HiFi> HiFis { get; set; }
        public DbSet<HiFiCategory> HiFiCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CAPANI\\SQLEXPRESS;Database=HiFiAppDb;User=sa;Password=gS53871905;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HiFiCategory>().HasKey(hc=>new {hc.HiFiId, hc.CategoryId});
            base.OnModelCreating(modelBuilder);
        }
    }
}