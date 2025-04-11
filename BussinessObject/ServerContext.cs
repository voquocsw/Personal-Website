using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class ServerContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Category_Product> Category_Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQLDB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(od => new { od.OrderId, od.ProductId });
                entity.HasOne(od => od.Order).WithMany(o => o.OrderDetails).HasForeignKey(od => od.OrderId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(od => od.Product).WithMany(o => o.OrderDetails).HasForeignKey(od => od.ProductId).OnDelete(DeleteBehavior.NoAction);
            });



            modelBuilder.Entity<Category_Product>(entity =>
            {
                entity.HasKey(cp => new { cp.CategoryId, cp.ProductId });
            });
                

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(o => o.Account).WithMany(a => a.Orders).HasForeignKey(o => o.AccountId);
            });
        }
    }
}
