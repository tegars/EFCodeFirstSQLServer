using FirstEF.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstEF.EntityFramework
{
    public class DBContext : DbContext
    {
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost;database=FirstEF;user=sa;password=aaaa123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasIndex(c => c.Id);
            modelBuilder.Entity<Product>().HasIndex(c => c.Id);
            modelBuilder.Entity<Category>()
                .HasMany<Product>(g => g.Products)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId);

            
            Category category = new Category();
            category.Id = 1;
            category.Name = "Fashion Wanita";
            modelBuilder.Entity<Category>().HasData(category);

            Category category2 = new Category();
            category2.Id = 2;
            category2.Name = "Fashion Pria";
            modelBuilder.Entity<Category>().HasData(category2);

            Category category3 = new Category();
            category3.Id = 3;
            category3.Name = "Handphone";
            modelBuilder.Entity<Category>().HasData(category3);
        }
    }
}
