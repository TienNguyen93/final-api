using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using CustomerAPI.Models;
using System.Collections.Generic;

namespace CustomerAPI.Models
{
    public class CustomerAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public CustomerAPIDBContext(DbContextOptions<CustomerAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("CustomerOrder");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
    }
}
