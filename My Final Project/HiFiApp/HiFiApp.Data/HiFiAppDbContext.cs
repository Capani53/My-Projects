using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiFiApp.Data.Concrete.EfCore.Configs;
using HiFiApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HiFiApp.Data
{
    public class HiFiAppDbContext:DbContext    
    {
        public HiFiAppDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HiFi> HiFis { get; set; }
        public DbSet<HiFiCategory> HiFiCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}