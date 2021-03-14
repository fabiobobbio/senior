using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Orchard.Domain;

namespace Orchard.Repository
{
    public class OrchardContext : DbContext
    {
        public OrchardContext(DbContextOptions<OrchardContext> options) : base(options){}
        public DbSet<Tree> Trees { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<Harvest> Harvests { get; set; }
        public DbSet<TreeGroup> TreeGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assemblyWithConfiguration = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfiguration);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"Data Source=127.0.0.1:49161/xe; User Id=system;Password=oracle;");
        }
    }
}