using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_commerce_Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_InfraStrucure.Data
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options) 
        {

                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
           .HasOne(o => o.Customer)
           .WithMany(c => c.Orders)
           .HasForeignKey(o => o.CustomerId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            modelBuilder.Entity<Product>().HasData(
        new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop", Price = 1200.99, Stock = 15 },
        new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 799.99, Stock = 25 },
        new Product { Id = 3, Name = "Headphones", Description = "Noise-canceling headphones", Price = 199.99, Stock = 50 },
        new Product { Id = 4, Name = "Keyboard", Description = "Mechanical keyboard", Price = 99.99, Stock = 30 });

            modelBuilder.Entity<Customer>().HasData(
              new Customer { Id = 1, Name = "Ahmed", Email = "ahmed@gmail.com", Phone = "01112840812" },
              new Customer { Id = 2, Name = "ARAFA", Email = "arafa@gmail.com", Phone = "0224457386" });
    


              modelBuilder.Entity<Order>().HasData(
        new Order
        {
            Id = 1,
            CustomerId = 1,
            OrderDate = DateTime.Now,
            Status = "Pending",
            TotalPrice = 200.00
        },
        new Order
        {
            Id = 2,
            CustomerId = 2,
            OrderDate = new DateTime(2025, 3, 28),
            Status = "Delivered",
            TotalPrice = 500.00
        } );
            modelBuilder.Entity<OrderProduct>().HasData(
    new OrderProduct
    {
        OrderId = 1,
        ProductId = 1,
        Quantity = 2
    });

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderedProduct { get; set; }

    }
}
