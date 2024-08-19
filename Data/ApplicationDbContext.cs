using AutoDB.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace AutoDB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }
        public DbSet<Car> Cars { get; set; } 
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<CarColor> Colors { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("MyConnectionString");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Model)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ModelId);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Color)
                .WithMany(col => col.Cars)
                .HasForeignKey(c => c.ColorId);

        }
    }

}
