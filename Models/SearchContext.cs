using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApplication2.Models
{
    public class SearchContext : DbContext
    {
        public SearchContext()
        {
            Database.EnsureCreated();
        }
        public SearchContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                //var connectionString = configuration.GetConnectionString("Search");
                //optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Input>().HasKey(c => c.DomainId);
            modelBuilder.Entity<Html>().HasKey(c => c.UrlId);
        }
    }
}
