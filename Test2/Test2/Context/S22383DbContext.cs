using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Test2.Models;

namespace Test2.Context
{
    public class S22383DbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public S22383DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfectioneryClientOrder>()
                .HasKey(c => new { c.IdClientOrder, c.IdConfectionery });
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<ClientOrder> ClientOrder { get; set; }
        public DbSet<Confectionery> Confectionery { get; set; }
        public DbSet<ConfectioneryClientOrder> ConfectioneryClientOrder { get; set; }
        public DbSet<Employee> Employee { get; set; }
        
    }
}