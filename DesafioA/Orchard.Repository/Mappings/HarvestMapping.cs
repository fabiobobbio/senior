using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orchard.Domain;

namespace Orchard.Repository.Mappings
{
    public class HarvestMapping : IEntityTypeConfiguration<Harvest>
    {
        public void Configure(EntityTypeBuilder<Harvest> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").ForOracleUseSequenceHiLo("HARVEST_SEQ");
            builder.Property(c => c.Information).HasColumnName("Information");
            builder.Property(c => c.Date).HasColumnName("Date");
            builder.Property(c => c.GrossWeight).HasColumnName("GrossWeight");
            builder.Property(c => c.TreeId).HasColumnName("TreeId");
        }
    }
}