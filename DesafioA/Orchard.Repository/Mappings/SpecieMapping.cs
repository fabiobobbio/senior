using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orchard.Domain;

namespace Orchard.Repository.Mappings
{
    public class SpecieMapping : IEntityTypeConfiguration<Specie>
    {
        public void Configure(EntityTypeBuilder<Specie> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").ForOracleUseSequenceHiLo("SPECIE_SEQ");
            builder.Property(c => c.Description).HasColumnName("Description");
        }
    }
}