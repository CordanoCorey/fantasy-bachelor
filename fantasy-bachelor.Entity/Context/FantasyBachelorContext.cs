using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace fantasy_bachelor.Entity.Context
{
    public partial class FantasyBachelorContext
    {
        public FantasyBachelorContext(DbContextOptions<FantasyBachelorContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.OnModelCreating_Identity(modelBuilder);
            this.OnModelCreating_Lookup(modelBuilder);
            this.OnModelCreating_Common(modelBuilder);
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FantasyBachelorContext>
        {
            public FantasyBachelorContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<FantasyBachelorContext>();
                var connectionString = configuration.GetConnectionString("db");
                builder.UseSqlServer(connectionString);
                return new FantasyBachelorContext(builder.Options);
            }
        }
    }
}
