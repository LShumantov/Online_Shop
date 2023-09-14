namespace OnlineShop.Data
{
    using OnlineShop.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category_Product>().HasKey(am => new
            {
                am.CategoryId,
                am.ProductId
            });
            modelBuilder.Entity<Category_Product>().HasOne(m => m.Product).WithMany(am => am.Categorys_Products).HasForeignKey(m => m.ProductId);
            modelBuilder.Entity<Category_Product>().HasOne(m => m.Category).WithMany(am => am.Categorys_Products).HasForeignKey(m => m.CategoryId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category_Product> Categorys_Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
