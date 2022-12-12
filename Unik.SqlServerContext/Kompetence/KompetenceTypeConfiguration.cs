using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Domain.Kompetence.Model;

namespace Unik.SqlServerContext.Kompetence
{
    public class KompetenceTypeConfiguration : IEntityTypeConfiguration<KompetenceEntity>
    {
        public void Configure(EntityTypeBuilder<KompetenceEntity> builder)
        {
            builder.ToTable("Kompetence", "kompetence");

            builder.HasKey(x => x.Id);

        }
    }
}
