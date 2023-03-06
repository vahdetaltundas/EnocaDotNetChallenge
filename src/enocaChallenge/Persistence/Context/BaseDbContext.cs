using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EnocaChallengeDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(c =>
            {
                c.ToTable("Companies").HasKey(k => k.Id);
                c.Property(p => p.Id).HasColumnName("Id");
                c.Property(p => p.CompanyName).HasColumnName("CompanyName").HasMaxLength(500);
                c.Property(p => p.IsActive).HasColumnName("IsActive");
                c.Property(p => p.OrderAllowStart).HasColumnName("OrderAllowStart");
                c.Property(p => p.OrderPermitEnd).HasColumnName("OrderPermitEnd");
                c.HasMany(p => p.Products);
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Products").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.CompanyId).HasColumnName("CompanyId");
                p.Property(p => p.ProductName).HasColumnName("ProductName").HasMaxLength(1000);
                p.Property(p => p.UnitsInStock).HasColumnName("UnitsInStock");
                p.Property(p => p.UnitPrice).HasColumnName("UnitPrice");
                p.HasOne(p => p.Company);
            });

        }



    }
}
