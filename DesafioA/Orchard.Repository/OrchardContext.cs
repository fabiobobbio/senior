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

            modelBuilder.HasSequence<int>("HARVEST_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<int>("SPECIE_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<int>("TREEGROUP_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<int>("TREE_SEQ").StartsAt(1).IncrementsBy(1);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"Data Source=127.0.0.1:49161/xe; User Id=system;Password=oracle;", options => options.UseOracleSQLCompatibility("11"));
        }
    }
}