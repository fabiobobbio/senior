using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orchard.Domain;

namespace Orchard.Repository.Mappings
{
    public class TreeMapping : IEntityTypeConfiguration<Tree>
    {
        public void Configure(EntityTypeBuilder<Tree> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").ForOracleUseSequenceHiLo("TREE_SEQ");
            builder.Property(c => c.Description).HasColumnName("Description");
            builder.Property(c => c.Age).HasColumnName("Age");
            builder.Property(c => c.SpecieId).HasColumnName("SpecieId");
        }
    }
}