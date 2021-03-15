using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orchard.Domain;

namespace Orchard.Repository.Mappings
{
    public class TreeGroupMapping : IEntityTypeConfiguration<TreeGroup>
    {
        public void Configure(EntityTypeBuilder<TreeGroup> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").ForOracleUseSequenceHiLo("TREEGROUP_SEQ");
            builder.Property(c => c.Name).HasColumnName("Name");
            builder.Property(c => c.Description).HasColumnName("Description");
            builder.Property(c => c.TreeId).HasColumnName("TreeId");
        }
    }
}